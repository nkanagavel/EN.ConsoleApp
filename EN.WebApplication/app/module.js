var app = angular.module("myapp", []);

app.controller("QuestionCtrl", function ($scope, $timeout, QuestionService) {

    $scope.Questions = [];
    QuestionService.GetModuleQuestions($scope.UserModel).then(function (response) {

        $scope.showResult = false;

        $scope.selectedOption;

        if (response.status === 200 && response.data) {
            // $scope.Questions = response.data;
            for (var i = 0; i < response.data.length; i++) {

                var question = {};

                question.Id = response.data[i].Id;
                question.Question = response.data[i].Question;

                var options = [];
                var option1 = {};

                option1.Option = response.data[i].Option1;
                option1.value = "Option1";
                option1.Selected = false;
                options.push(option1);

                var option2 = {};
                option2.Option = response.data[i].Option2;
                option2.value = "Option2";
                option2.Selected = false;
                options.push(option2);

                var option3 = {};
                option3.Option = response.data[i].Option3;
                option3.value = "Option3";
                option3.Selected = false;
                options.push(option3);

                var option4 = {};
                option4.Option = response.data[i].Option4;
                option4.value = "Option4";
                option4.Selected = false;
                options.push(option4);

                question.Options = options;
                question.Answer = response.data[i].Answer;

                $scope.Questions.push(question);
            }
        }

        //console.log(JSON.stringify(response.data));
    });

    $scope.SelectedAnswers = [];
    $scope.SelectAnswer = function (qId, optvalue, qAnswer) {

        var SelectedAnswer = {};
        var ExistingAnswer = $scope.SelectedAnswers.find(o => o.qId === qId);
        if (ExistingAnswer === undefined) {
            SelectedAnswer.qId = qId;
            SelectedAnswer.optvalue = optvalue;
            SelectedAnswer.qAnswer = qAnswer;
            $scope.SelectedAnswers.push(SelectedAnswer);
        }

        else {
            ExistingAnswer.optvalue = optvalue;
        }
    };

    $scope.submitAnswer = function (question) {

        var ExistingAnswer = $scope.SelectedAnswers.find(o => o.qId === question.Id);

        if (ExistingAnswer !== undefined) {
            if (ExistingAnswer.optvalue === ExistingAnswer.qAnswer)
                alert("Correct Answer.");
            else
                alert("Incorrect Answer.");
        }
    }

    $scope.attemptedQuestion = 0;
    $scope.totalRightAnswer = 0;
    $scope.totalWrongAnswer = 0;
    $scope.Result = "Fail";

    $scope.CheckResult = function () {

        if ($scope.SelectedAnswers.length > 0) {

            $scope.showResult = true;
            $scope.totalQuestion = $scope.Questions.length;

            var rightcount = 0;
            for (var i = 0; i <= $scope.SelectedAnswers.length - 1; i++) {
                if ($scope.SelectedAnswers[i].optvalue === $scope.SelectedAnswers[i].qAnswer)
                    rightcount++;
                $scope.totalRightAnswer = rightcount;
            }

            var wrongcount = 0;
            for (var j = 0; j <= $scope.SelectedAnswers.length - 1; j++) {
                if ($scope.SelectedAnswers[j].optvalue !== $scope.SelectedAnswers[j].qAnswer)
                    wrongcount++;
                $scope.totalWrongAnswer = wrongcount;
            }

            $scope.attemptedQuestion = $scope.SelectedAnswers.length;
            $scope.missedQuestions = $scope.totalQuestion - $scope.attemptedQuestion;

            var marks = Math.round(($scope.totalRightAnswer / $scope.totalQuestion) * 100);

            $scope.Result = marks >= 50 ? "Pass" : "Fail";

            $timeout(loadChart, 500);
        }

    }

    function loadChart() {
        Highcharts.chart('container', {
            chart: {
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false,
                type: 'pie'
            },
            tooltip: {
                pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: false
                    },
                    showInLegend: true
                }
            },
            series: [{
                name: 'Percentage',
                colorByPoint: true,
                data: [{
                    name: 'Correct Answer',
                    y: $scope.totalRightAnswer
                }, {
                    name: 'Wrong Answer',
                    y: $scope.totalWrongAnswer,
                    sliced: true,
                    selected: true
                },
                 {
                     name: 'Question Attended',
                     y: $scope.attemptedQuestion
                 }]
            }]
        });
    }

});

app.controller("UserCtrl", function ($scope, $timeout, UserService) {

    $scope.RegisterUser = function () {
        var user = {
            Id: $scope.Id,
            Name: $scope.Name,
            IcNumber: $scope.IcNumber,
            Phonenumber: $scope.Phonenumber,
            MailId: $scope.MailId
        }

        UserService.RegisterUser(user).then(function (response) {
            if (response.status === 200 && response.data) {
                if (response.data.result === "success") {
                    clearfields();
                    GetUsers();
                    alert("Users Registered.");
                }
                else {
                    alert("failed to insert.")
                }
            }
            console.log(response);
        });
    }

    $scope.Reset = function () {
        clearfields();
    }

    $scope.clearSearchBox = function () {
        $Scope.SearchText = "";
    }

    $scope.Id = 0;
    $scope.GetUserById = function (user) {
        $scope.Id = user.Id;
        $scope.Name = user.Name;
        $scope.IcNumber = user.IcNumber;
        $scope.Phonenumber = user.Phonenumber;
        $scope.MailId = user.MailId;
    }

    $scope.Users = [];
    GetUsers();

    function GetUsers() {
        UserService.GetUsers().then(function (response) {
            if (response.status === 200 && response.data) {
                $scope.Users = response.data;
            }

        });
    }



    function clearfields() {
        $scope.Id = "";
        $scope.Name = "";
        $scope.IcNumber = "";
        $scope.Phonenumber = "";
        $scope.MailId = "";
    }

});








app.service("QuestionService", function ($http) {

    this.GetModuleQuestions = function () {
        var response = $http({
            method: "Get",
            url: "/Learning/GetModuleQuestions?moduleId=1",
            dataType: "json"
        });
        return response;
    }



});

app.service("UserService", function ($http) {

    this.RegisterUser = function (user) {
        var response = $http({
            method: "Post",
            url: "/User/RegisterUser",
            data: user,
            dataType: "json"
        });
        return response;
    },
    this.GetUsers = function (user) {
        var response = $http({
            method: "Get",
            url: "/User/GetUsers",
            dataType: "json"
        });
        return response;
    }




});