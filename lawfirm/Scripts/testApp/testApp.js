var app = angular.module("testApp", []);

app.filter("secondsToDateTime", function () {
    return function (seconds) {
        var d = new Date(0, 0, 0, 0, 0, 0, 0);
        d.setSeconds(seconds);
        return d;
    };
});
app.controller("testCtr", function ($http, $scope, $interval) {

    $scope.test = {};
    var req = {
        Id: $("#TypeId").val()
    };
    $http.post("Test", req).then(function (response) {
        $scope.test = response.data;
        console.log(response.data);
    }, function (response) {
        alert(response.status);
    });

    $scope.StartTest = function () {
        if ($scope.test.quantityQuestion != undefined
            && $scope.test.quantityQuestion > 0
            && ($scope.test.subjectOther != undefined
            || $scope.test.subject != undefined)
            && $scope.test.nameTest !== '') {
            var req = {
                Time: $scope.test.amountOfTime,
                Quantity: $scope.test.quantityQuestion,
                QuestionLevelId: ($scope.test.questionLevel !== undefined && $scope.test.questionLevel !== null) ? $scope.test.questionLevel.Id : 0,
                MonHocId: $scope.test.subject.Id,
                SubjectId: ($scope.test.subjectOther !== undefined && $scope.test.subjectOther !== null) ? $scope.test.subjectOther.Id : 0,
                NameTest: $scope.test.nameTest
            };
            $scope.countDown = 0; // number of seconds remaining
            var stop;

            $scope.timerCountdown = function () {
                // set number of seconds until the pizza is ready
                $scope.countDown = 60 * $scope.practiceTest.AmountTime;

                // start the countdown
                stop = $interval(function () {
                    // decrement remaining seconds
                    $scope.countDown--;
                    // if zero, stop $interval and show the popup
                    if ($scope.countDown === 0) {
                        $interval.cancel(stop);
                    }
                }, 1000, 0); // invoke every 1 second
            };
            $http.post("../GetTest", req).then(function (response) {
                if (response.data == null) {
                    alert("Có lỗi không thể thực hiện làm bài!");
                } else {
                    $scope.practiceTest = response.data;
                    if ($scope.practiceTest.AmountTime > 0) {
                        $scope.timerCountdown();
                    }
                }
            }, function (response) {
                alert(response.status);
            });
        }

    };
    $scope.workSheet = [];
    $scope.addAns = function (id, ans) {
        if ($scope.workSheet.length <= 0) {
            var a = {
                Id: id,
                Answer: ans
            };
            $scope.workSheet.push(a);
            console.log($scope.workSheet);
            return;
        } else {
            var temp = 0;
            $scope.workSheet.forEach(function (v) {
                if (v.Id === id) {
                    v.Answer = ans;
                    console.log($scope.workSheet);
                    temp++;
                }
            });
            if (temp === 0) {
                var aa = {
                    Id: id,
                    Answer: ans
                };
                $scope.workSheet.push(aa);
                console.log($scope.workSheet);

            }
        }
    };
    $scope.doneTest = function () {
        var questAns = [];
        $scope.workSheet.forEach(function (v) {
            var qa = {
                Id: v.Id,
                AnswerId: v.Answer.Id
            };
            questAns.push(qa);
        });
        if ($scope.practiceTest.Id <= 0) {
            alert("Đã có lỗi xảy ra vui lòng thử lại sau!");
        } else {
            if (questAns.length <= 0) {
                alert("Lỗi bạn chưa thực hiện bài kiểm tra!");
                return;
            }
            var req = {
                Id: $scope.practiceTest.Id,
                ListAnswers: questAns
            };
            $http.post("../DoneTest", req).
                then(function (response) {
                    var res = response.data;
                    $scope.testResult = res;
                    //console.log(res);
                    //alert("Chúc mừng bạn đã hoàn thành bài kiểm tra! (Số câu đúng: " + res.NumberRight + "/" + res.NumberQuestion + ", xếp hạng: " + res.Result);
                    $(".box-test").remove();
                    $(".box-testDone").appendTo(".main");
                }, function (response) {
                    alert(response.status + " server error");
                });
        }

    };
    $scope.btnClear = function () {
        $scope.test.quantityQuestion = "";
        $scope.test.amountOfTime = "";
        $scope.test.questionLevel = "?";
        $scope.test.questionLevel = undefined;
        $scope.test.levelSchool = "?";
        $scope.test.levelSchool = undefined;
        $scope.test.class = "?";
        $scope.test.class = undefined;
        $scope.test.subject = "?";
        $scope.test.subject = undefined;
        $scope.test.subjectOther = "?";
        $scope.test.subjectOther = undefined;
        $scope.test.nameTest = "";
    }
});