<!--
var rollspeed = 30;
var myInter;
function StartRoll(direction) {
	if (direction == 'V') {
		StartRollV();
	} else {
		StartRollH();
	}
}
function MarqueeV()
{
	var ooRoll = document.getElementById("oRoll");
	var ooRoll1 = document.getElementById("oRoll1");
	var ooRoll2 = document.getElementById("oRoll2");
	if(ooRoll2.offsetTop - ooRoll.scrollTop <= 0)
	{
		ooRoll.scrollTop -= ooRoll1.offsetHeight;
	}
	else
	{
		ooRoll.scrollTop++;
	}
}
function StartRollV()
{
	var ooRoll = document.getElementById("oRoll");
	var ooRoll1 = document.getElementById("oRoll1");
	var ooRoll2 = document.getElementById("oRoll2");
	if (ooRoll) {
		if (parseInt(ooRoll.style.height) >= ooRoll2.offsetTop)
		{
			ooRoll.style.height = ooRoll2.offsetTop;
			return;
		}
		ooRoll2.innerHTML = ooRoll1.innerHTML;
		myInter = setInterval(MarqueeV,rollspeed);
		ooRoll.onmouseover = function() {
			clearInterval(myInter)
		};
		ooRoll.onmouseout = function() {
			myInter = setInterval(MarqueeV,rollspeed)
		};
	}
}
function MarqueeH()
{
	var ooRoll = document.getElementById("oRoll");
	var ooRoll1 = document.getElementById("oRoll1");
	var ooRoll2 = document.getElementById("oRoll2");
	if(ooRoll2.offsetLeft - ooRoll.scrollLeft <= 0)
	{
		ooRoll.scrollLeft -= ooRoll1.offsetWidth;
	}
	else
	{
		ooRoll.scrollLeft++;
	}
}
function StartRollH()
{
	var ooRoll = document.getElementById("oRoll");
	var ooRoll1 = document.getElementById("oRoll1");
	var ooRoll2 = document.getElementById("oRoll2");
	if (ooRoll)
	{
		if (parseInt(ooRoll.style.width) >= ooRoll2.offsetLeft)
		{
			oRoll.style.width = oRoll2.offsetLeft;
			return;
		}
		ooRoll2.innerHTML = ooRoll1.innerHTML;
		myInter = setInterval(MarqueeH,rollspeed);
		ooRoll.onmouseover = function() {
			clearInterval(myInter)
		};
		ooRoll.onmouseout = function() {
			myInter = setInterval(MarqueeH,rollspeed)
		};
	}
}
// -->