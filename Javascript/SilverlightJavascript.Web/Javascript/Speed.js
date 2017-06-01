var speedPage;
var canvas;
var canvasHeight;
var meanCorrect = new Array();
var meanIncorrect = new Array();
var interval;
var singleUnit;
var topMargin;
var bottomMargin;
var counter = 0;
var counterInc = 0;
var height = 468;
var correctMin;
var correctMax;
var incorrectMin;
var incorrectMax;
var startId;
var correct;
var incorrect;
var min1;
var max1;

function onLoaded() {
    speedPage = document.getElementById('SpeedPage');
    canvas = speedPage.content.findName('canvas');
    initMeanCorrect();
    initMeanIncorrect();
    singleUnit = parseFloat(speedPage.content.findName('correctDot')['Tag']);
    topMargin = parseInt(speedPage.content.findName('xAxisTop')['Tag']);
    bottomMargin = height - parseInt(speedPage.content.findName('xAxisBottom').Tag);
    canvasHeight = (height - bottomMargin - topMargin) - 3
    initIncorrect();
    initCorrect();
    initLimits();
    
  }

//UTILITY
function initMeanCorrect() {
    for (var i = 0; i < 3; i++) {
        meanCorrect[i] = speedPage.content.findName('correct' + i);
    }
}

function initMeanIncorrect() {
    for (var i = 0; i < 3; i++) {
        meanIncorrect[i] = speedPage.content.findName('incorrect' + i);
    }
}

function initCorrect() {
    correct = new Array();
    for (var i = 0; i < 3; i++) {
        correct[i] = parseInt(speedPage.content.findName('correcteMetingen' + i)['Tag']);
    }
}

function initIncorrect() {
    incorrect = new Array();
    for (var i = 0; i < 3; i++) {
        incorrect[i] = parseInt(speedPage.content.findName('incorrecteMetingen' + i)['Tag']);
    }
}

function initLimits() {
    correctMin = new Array();
    correctMax = new Array();
    incorrectMin = new Array();
    incorrectMax = new Array();

    min1 = (((topMargin * 2) - bottomMargin) - (singleUnit) - 4 - (500 * singleUnit));

    max1 = (((topMargin * 2) - bottomMargin) - (singleUnit * 3500) + 14 - (500 * singleUnit));

    var increase = 0;
    if (incorrect[1] < 3000 && (incorrect[1] % 1000 == 100)) {
        increase = 200;
    }


    incorrectMin[0]=(((topMargin * 2) - bottomMargin) - (singleUnit) - 22 - (1000 * singleUnit));
    incorrectMin[1]=(((topMargin * 2) - bottomMargin) - (singleUnit) - 22 - (1000 * singleUnit)-Math.abs(incorrect[0]-incorrect[1])+increase);
    incorrectMin[2]=(((topMargin * 2) - bottomMargin) - (singleUnit) - 22 - ((1000 * singleUnit)-Math.abs((incorrect[0]-incorrect[2])*singleUnit)));

    incorrectMax[0]=(((topMargin * 2) - bottomMargin) - (singleUnit * 4500) + 24 - (height * singleUnit));
    incorrectMax[1]=(((topMargin * 2) - bottomMargin) - (singleUnit * 4600) + 24 - (height * singleUnit));
    incorrectMax[2]=(((topMargin * 2) - bottomMargin) - (singleUnit * 4950) + 24 - (height * singleUnit));

    correctMin[0] = min1;
    correctMax[0] = max1;
}

function showMeanCorrect() {
    for (var i = 0; i < 3; i++) {
        meanCorrect[i]['Visibility'] = 'Visible';
    }
}

function showMeanIncorrect() {
    for (var i = 0; i < 3; i++) {
        meanIncorrect[i]['Visibility'] = 'Visible';
    }
}

function randomFromInterval(from, to) {
    return Math.floor(Math.random() * (to - from + 1) + from);
}

function setCanvasPositions(canvas,min,max) {
        canvas['Canvas.Top'] = randomFromInterval(parseFloat(min), parseFloat(max));   
}

//FUNCTIONALITY
function handleMeanCorrect() {
    counter++;
    switch (counter) {
        case 1:
            showMeanCorrect();
            break;
        case 2:
            animateCorrect();
            break;
        case 3:
            reset(meanCorrect, counter);
            counter = 0;
            break;
    }
}

function animate(){
    intervRandom1 = setInterval('setCanvasPositions(meanIncorrect[0], incorrectMin[0], incorrectMax[0])', 200);
    intervRandom2 = setInterval('setCanvasPositions(meanIncorrect[1], incorrectMin[0], incorrectMax[1])', 200);
    intervRandom3 = setInterval('setCanvasPositions(meanIncorrect[2], incorrectMin[0], incorrectMax[1])', 200);
}

function animateCorrect() {
    intervRandomc1 = setInterval('setCanvasPositions(meanCorrect[0], incorrectMin[0], max1)', 200);
    intervRandomc2 = setInterval('setCanvasPositions(meanCorrect[1], incorrectMin[0], max1)', 200);
    intervRandomc3 = setInterval('setCanvasPositions(meanCorrect[2], incorrectMin[0], max1)', 200);
}

function handleMeanIncorrect() {
    counterInc++;
    switch (counterInc) {
        case 1:
            showMeanIncorrect();
            break;
        case 2:
            initLimits();
            animate();
            break;
        case 3:
            reset(meanIncorrect);
            counterInc = 0;
            break;
    }
}

function reset(arr) {
    for (var i = 0; i < arr.length; i++) {
        arr[i]['Visibility'] = 'Collapsed';
    }
}

