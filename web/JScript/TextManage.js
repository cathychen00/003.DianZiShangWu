<!--
function ChkRemark()
{
	var form = document.getElementById("RemarkForm");
	if(form.body.value == "")
	{
		alert("����д��������");
		form.body.focus();
		return false;
	}
	if(form.body.value.length > 255)
	{
		alert("�������ݲ����Գ���255��");
		form.body.focus();
		return false;
	}
	form.submit.disabled = true;
	return true;
}

function showLen(obj)
{
	var bodyLen = document.getElementById("bodyLen");
	if (obj.value.length < 1000)
	{
		bodyLen.value = (obj.value.length < 10 ? "00" : obj.value.length < 100 ? "0" : "") + obj.value.length + "/255";
	}
	else
	{
		bodyLen.value = ".../255";
	}
}

function ContentSize(size)
{
	var obj = document.getElementById("BodyText");
	obj.style.fontSize = size + "px";
}
// -->