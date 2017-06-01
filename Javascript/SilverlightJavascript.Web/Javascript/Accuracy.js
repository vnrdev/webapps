var accuracyPage;
var bars = new Array();
var barValues = new Array();
var canvas;
var clickCounter = 0;
var borderClickCounter = 0;
var sumButtons = new Array();
var borderClicked = false;
var legendClicked = false;
var canvasClicked = false;
var legendCounter = 0;

function onLoaded() {
    //alert('in Accuracy');
    accuracyPage = document.getElementById('AccuracyPage');
    canvas = accuracyPage.content.findName('canvas');

    addBars();
    addBarValues();
    addSumButtons();
}

function addBars() {
    for (var i = 0; i < 9; i++) {
        bars[i] = accuracyPage.content.findName("bar" + i);
    }
}

function addBarValues() {
    for (var i = 0; i < 9; i++) {
        barValues[i] = accuracyPage.content.findName("barValue" + i);
    }
}

function addSumButtons() {
    for (var i = 0; i < 3; i++) {
        sumButtons[i] = accuracyPage.content.findName("sumButton" + i);
    }
}

function showBarValues() {
    for (var i = 0; i < barValues.length; i++) {
        barValues[i]['Visibility'] = 'Visible';
    }
}

function showBars() {
    for (var i = 0; i < bars.length; i++) {
        bars[i]['Visibility'] = 'Visible';
    }
    showBarValues();
}

function handleCanvas() {
    canvasClicked = true;
    if (borderClicked == false && legendClicked == false) {
        clickCounter++;
        if (clickCounter % 2 == 1) {
            showBars();
        } else if (clickCounter % 2 == 0) {
            reset();
        }
    } else if (borderClicked || legendClicked) {
        canvasClicked = false;
        borderClicked = false;
        clickCounter = 0;
        borderClickCounter = 0;
        legendClicked = false;
    }
}

function hideRestBars() {
    for (var j = 3; j < 9; j++) {
        bars[j]['Visibility'] = 'Collapsed';
        barValues[j]['Visibility'] = 'Collapsed';
    }
}

function reset() {
    for (var i = 0; i < bars.length; i++) {
        bars[i]['Visibility'] = 'Collapsed';
        barValues[i]['Visibility'] = 'Collapsed';
    }
    canvasClicked = false;
    borderClicked = false;
    clickCounter = 0;
    borderClickCounter = 0;
}

function series1() {
    borderClickCounter++;
    if (borderClickCounter % 2 == 0) {
        //...
    }

    if (canvasClicked == false) {
        borderClicked = true;
        for (var i = 0; i < 9; i++) {
            bars[i % 3]['Visibility'] = 'Visible';
            barValues[i % 3]['Visibility'] = 'Visible';
        }
        for (var j = 3; j < 9; j++) {
            bars[j]['Visibility'] = 'Collapsed';
            barValues[j]['Visibility'] = 'Collapsed';
        }
    }
}

function series2() {
    if (canvasClicked == false) {
        borderClicked = true;
        for (var i = 3; i < 6; i++) {
            bars[i % 3]['Visibility'] = 'Collapsed';
            barValues[i % 3]['Visibility'] = 'Collapsed';

            bars[i]['Visibility'] = 'Visible';
            barValues[i]['Visibility'] = 'Visible';

            bars[i + 3]['Visibility'] = 'Collapsed';
            barValues[i + 3]['Visibility'] = 'Collapsed';
        }
    }
}

function series3() {
    if (canvasClicked == false) {
        borderClicked = true;
        for (var i = 6; i < 9; i++) {
            bars[i]['Visibility'] = 'Visible';
            barValues[i]['Visibility'] = 'Visible';

            bars[i % 6]['Visibility'] = 'Collapsed';
            barValues[i % 6]['Visibility'] = 'Collapsed';

            bars[(i - 3) % 6]['Visibility'] = 'Collapsed';
            barValues[(i - 3) % 6]['Visibility'] = 'Collapsed';
        }
    }
}

function showLegend1() {
    if (canvasClicked == false) {
        legendClicked = true;


        var counter = 0;
        var show = '';
        for (var i = 0; i < 9; i++) {
            switch (i) {
                case 0:
                    show = 'Visible';
                    break;
                case 3:
                    show = 'Visible';
                    break;
                case 6:
                    show = 'Visible';
                    break;
                default:
                    show = 'Collapsed';
                    break;
            }
            bars[i % bars.length]['Visibility'] = show;
            barValues[i % bars.length]['Visibility'] = show;
        }
    }
}

function showLegend2() {
    if (canvasClicked == false) {
        legendClicked = true;

        var counter = 0;
        var show = '';
        for (var i = 0; i < 9; i++) {
            switch (i) {
                case 1:
                    show = 'Visible';
                    break;
                case 4:
                    show = 'Visible';
                    break;
                case 7:
                    show = 'Visible';
                    break;
                default:
                    show = 'Collapsed';
                    break;
            }
            bars[i % bars.length]['Visibility'] = show;
            barValues[i % bars.length]['Visibility'] = show;
        }
    }
}

function showLegend3() {
    legendClicked = true;

    var counter = 0;
    var show = '';
    for (var i = 0; i < 9; i++) {
        switch (i) {
            case 2:
                show = 'Visible';
                break;
            case 5:
                show = 'Visible';
                break;
            case 8:
                show = 'Visible';
                break;
            default:
                show = 'Collapsed';
                break;
        }
        bars[i % bars.length]['Visibility'] = show;
        barValues[i % bars.length]['Visibility'] = show;
    }
}







