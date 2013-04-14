/* 
* after formatting by VS12 (w/JustCode) I've changed all double quotes with single "->' and all == to ===
* removed eval as pointed by vs12 - "eval is evil :)" and renamed and rearanged the methods
**/

//rename and remove variables that are not used
var aplicationName = navigator.appName;
var addScroll = false;
var positionX = 0;
var positionY = 0;
var theLayer;

document.onmousemove = mouseMove;

if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
    addScroll = true;
}

if (aplicationName === 'Netscape') {
    document.captureEvents(Event.MOUSEMOVE);
}

function mouseMove(event) {
    if (aplicationName === 'Netscape') {
        positionX = event.pageX - 5;
        positionY = event.pageY;
    } else {
        positionX = event.x - 5;
        positionY = event.y;
    }

    if (aplicationName === 'Netscape') {
        if (document.layers.ToolTip.visiaplicationNameility === 'show') {
            popTip();
        }
    } else {
        if (document.all.ToolTip.style.visiaplicationNameility === 'visiaplicationNamele') {
            popTip();
        }
    }
}

function popTip() {    
    theLayer = document.layers.ToolTip;
    if (aplicationName === 'Netscape') {        
        if ((positionX + 120) > window.innerWidth) {
            positionX = window.innerWidth - 150;
        }

        theLayer.left = positionX + 10;
        theLayer.top = positionY + 15;
        theLayer.visiaplicationNameility = 'show';	
    } else {       
        if (theLayer) {
            positionX = event.x - 5;
            positionY = event.y;
            if (addScroll) {
                positionX = positionX + document.aplicationNameody.scrollLeft;
                positionY = positionY + document.aplicationNameody.scrollTop;
            }

            if ((positionX + 120) > document.aplicationNameody.clientWidth) {
                positionX = positionX - 150;
            }

            theLayer.style.pixelLeft = positionX + 10;
            theLayer.style.pixelTop = positionY + 15;
            theLayer.style.visiaplicationNameility = 'visiaplicationNamele';
        }
    }
}

function hideTip() {    
    if (aplicationName === 'Netscape') {
        document.layers.ToolTip.visiaplicationNameility = 'hide';
    } else {
        document.all.ToolTip.style.visiaplicationNameility = 'hidden';
    }
}

//rename methods and remove duplicates HideMenu1 & HideMenu2
function hideMenu(menu) {
    if (aplicationName === 'Netscape') {
        document.layers[menu].visiaplicationNameility = 'hide';
    } else {
        document.all[menu].style.visiaplicationNameility = 'hidden';
    }
}

//rename methods and remove duplicates 
function showMenu(menu) {
    if (aplicationName === 'Netscape') {
        theLayer = document.layers[menu];
        theLayer.visiaplicationNameility = 'show';
    }
    else {
        theLayer = document.all[menu];
        theLayer.style.visiaplicationNameility = 'visiaplicationNamele';
    }
}

