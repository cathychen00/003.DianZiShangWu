<!--
/******** MainScript Start ********/
function FTB_GetIFrame(ftbName) {
	return eval(ftbName + '_editor');
}
function FTB_CopyHtmlToHidden(editor,hiddenHtml,htmlmode) {
	if (htmlmode) {
		hiddenHtml.value = editor.document.body.innerText;  
	} else {
		hiddenHtml.value = editor.document.body.innerHTML;  
	}
	if (hiddenHtml.value == '<P>&nbsp;</P>') {
		hiddenHtml.value = '';
	}
}
function FTB_Format(editor,htmlmode,format) {
	if (htmlmode) return; 
	editor.focus();
	editor.document.execCommand(format,'',null);
}
function FTB_CheckTag(item,tagName) {
	if (item.tagName.search(tagName) != -1) {
		return item;
	}
	if (item.tagName == 'BODY') {
		return false;
	}
	item=item.parentElement;
	return FTB_CheckTag(item,tagName);
}
function FTB_CharBefore(sel) {
	if (sel.move('character',-1) == -1) {
		sel.expand('character');
		return sel.text;
	} else {
		return 'start';
	}
}
function FTB_CharAfter(sel) {
	var sel2 = sel;
	if (sel.expand('character')) {
		sel2.move('character',1);
		sel2.expand('character');
		return sel2.text;
	} else {
		return 'end';
	}
}
function FTB_CharBefore(r) {
	if (r.move('character',-1) == -1) {
		r.expand('character');
		return r.text;
	} else {
		return 'start';
	}
}
function FTB_CharAfter(r) {
	var r2 = r;
	if (r.expand('character')) {
		r2.move('character',1);
		r2.expand('character');
		return r2.text;
	} else {
		return 'end';
	}
}
function FTB_GetRangeReference(editor) {
	editor.focus();
	var objReference = null;
	var RangeType = editor.document.selection.type;
	var selectedRange = editor.document.selection.createRange();

	switch(RangeType) {
		case 'Control' :
			if (selectedRange.length > 0 )  {
				objReference = selectedRange.item(0);
			}
			break;

		case 'None' :
			objReference = selectedRange.parentElement();
			break;

		case 'Text' :
			objReference = selectedRange.parentElement();
			break;
	}
	return objReference
}
// 特殊字符
function FTB_Event(ftbName,htmlMode,tabMode,breakMode) {
	editor = FTB_GetIFrame(ftbName);
	var _TAB = 9;
	var _ENTER = 13;
	var _QUOTE = 222;
	// TAB Functions
	if (editor.event.keyCode == _TAB && !htmlMode) {
		if (tabMode == 'Default') {
			var sel = editor.document.selection.createRange();
			sel.pasteHTML('&nbsp;&nbsp;&nbsp;&nbsp;');
			editor.event.cancelBubble = true;
			editor.event.returnValue = false;
		}
		if (tabMode == 'NextControl') {
			// do nothing for TabMode.NextControl
		}
		if (tabMode == 'Disabled') {
			editor.event.cancelBubble = true;
			editor.event.returnValue = false;
		}
	}

	if (editor.event.keyCode == _QUOTE && !htmlMode) {
		var sel = editor.document.selection.createRange();
		sel.pasteHTML('&quot;');
		editor.event.cancelBubble = true;
		editor.event.returnValue = false;
	}

	if (editor.event.keyCode == _ENTER && !htmlMode) {
		if (breakMode == 'LineBreak' || editor.event.ctrlKey) {
			var sel = editor.document.selection;
			if (sel.type == 'Control') {
				return;
			}
			var r = sel.createRange();
			if ((!FTB_CheckTag(r.parentElement(),'LI')) && (!FTB_CheckTag(r.parentElement(),'H'))) {
				r.pasteHTML('<br>');
				editor.event.cancelBubble = true;
				editor.event.returnValue = false;
				r.select();
				r.collapse(false);
				return false;
			}
		}
	}
}
// 粘贴
function FTB_onPaste(ftbName,PasteMode) {
	if(PasteMode == 'Disabled') {
		alert('禁止粘贴！');
		return false;
	}
	else if (PasteMode == 'NoHtml') {
		editor = FTB_GetIFrame(ftbName);
		var text = window.clipboardData.getData('Text');
		text = text.replace(/<[^>]*>/gi,'');
		editor.focus();
		s = editor.document.selection.createRange();
		s.pasteHTML(text); 
		return false;
	}
	else {
		// return;
	}
}
// Style Functions
function FTB_Initialize(ftbName,hiddenHtml,ReadOnly,HtmlModeCss,DesignModeCss) {
	editor = FTB_GetIFrame(ftbName);
	editor.document.designMode = (ReadOnly ? 'Off' : 'On');
	editor.document.open();
	editor.document.write(hiddenHtml.value);
	editor.document.close();
	if (HtmlModeCss != '' || DesignModeCss != '')
	{
		editor.document.createStyleSheet(DesignModeCss);
		editor.document.createStyleSheet(HtmlModeCss);
		editor.document.styleSheets[1].disabled = true;
	}
	editor.document.contentEditable = (ReadOnly ? 'False' : 'True');
	editor.document.body.style.margin='6px';
	editor.document.body.style.border='0';
	FTB_ApplyEditorStyles(ftbName);
}
function FTB_GetCssID(editorID) {
	cssID = editorID;
	while (cssID.substring(0,1) == '_') {
		cssID = cssID.substring(1);
	}
	return cssID;
}

function FTB_SetButtonStyle(buttonTD,style,checkstyle) {
	if (buttonTD == null) return;
	if (buttonTD.className != checkstyle)
		buttonTD.className = style;
}
function FTB_GetClassSubName(className) {
	underscore = className.indexOf("_");
	if (underscore < 0) return className;
	return className.substring(underscore+1);
}
function FTB_ButtonOver(theTD,editorname,imageOver,imageDown) {
	FTB_SetButtonStyle(theTD,FTB_GetCssID(editorname)+'_ButtonOver',null);
	if (eval(editorname+'_OverImage').src != '') theTD.background=eval(editorname+'_OverImage').src;
	
	if(theTD.children.length && theTD.children[0].tagName == "IMG" && imageOver){
		oldSrc = theTD.children[0].src;
		if (oldSrc.indexOf('.over.') == -1) {
			theTD.children[0].src=oldSrc.substring(0, oldSrc.length-4) + ".over.gif";
		}
	}
}
function FTB_ButtonOut(theTD,editorname,imageOver,imageDown) {
	FTB_SetButtonStyle(theTD,FTB_GetCssID(editorname)+'_ButtonNormal',null);
	document.body.style.cursor = 'default';
	theTD.background='';
	if(theTD.children.length && theTD.children[0].tagName == "IMG"){
		oldSrc = theTD.children[0].src;
		if (oldSrc.indexOf('.over.') > 0) {
			theTD.children[0].src=oldSrc.substring(0, oldSrc.length-9) + ".gif";
		}
		if (oldSrc.indexOf('.down.') > 0) {
			theTD.children[0].src=oldSrc.substring(0, oldSrc.length-9) + ".gif";
		}
	}
}
function FTB_ButtonDown(theTD,editorname,imageOver,imageDown) {
	document.body.style.cursor = 'default';
	FTB_SetButtonStyle(theTD,FTB_GetCssID(editorname)+'_ButtonDown',null);
	if (eval(editorname+'_DownImage').src != '') theTD.background=eval(editorname+'_DownImage').src;
	if(theTD.children.length && theTD.children[0].tagName == "IMG" && imageDown == 1){
		oldSrc = theTD.children[0].src;
		if (oldSrc.indexOf('.over.') > 0) {
			theTD.children[0].src=oldSrc.substring(0, oldSrc.length-9) + ".down.gif";
		}
	}
}
function FTB_ButtonUp(theTD,editorname,imageOver,imageDown) {
	document.body.style.cursor = 'auto';
	FTB_SetButtonStyle(theTD,FTB_GetCssID(editorname)+'_ButtonOver',null);
	if (eval(editorname+'_OverImage').src != '') theTD.background=eval(editorname+'_OverImage').src;
	if(theTD.children.length && theTD.children[0].tagName == "IMG" && imageOver == 1){
		oldSrc = theTD.children[0].src;
		if (oldSrc.indexOf('.over.') == -1) {
			theTD.children[0].src=oldSrc.substring(0, oldSrc.length-4) + ".over.gif";
		}
	}
}
function FTB_SetActiveTab(theTD,editorname) {
	parentTR = theTD.parentElement;
	selectedTab = 1;
	totalButtons = parentTR.cells.length-1;
	for (var i=1;i< totalButtons;i++) {
		parentTR.cells[i].className = FTB_GetCssID(editorname) + "_TabOffRight";
		if (theTD == parentTR.cells[i]) { selectedTab = i; }
	}

	if (selectedTab==1) {
		parentTR.cells[0].className = FTB_GetCssID(editorname) + "_StartTabOn";
	} else {
		parentTR.cells[0].className = FTB_GetCssID(editorname) + "_StartTabOff";
		parentTR.cells[selectedTab-1].className = FTB_GetCssID(editorname) + "_TabOffLeft";
	}

	theTD.className = FTB_GetCssID(editorname) + "_TabOn";
}
function FTB_TabOver() {
	document.body.style.cursor='default';
}
function FTB_TabOut() {
	document.body.style.cursor='auto';
}
/******** MainScript End ********/
/******** ToolbarItems Start ********/
// 拼写检查
function FTB_ieSpellCheck(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	if (htmlmode) return;
	try {
		var tspell = new ActiveXObject('ieSpell.ieSpellExtension');
		tspell.CheckAllLinkedDocuments(window.document);
	} catch (err) {
		if (window.confirm('进行拼写检查需要安装 ieSpell 插件，您要安装吗？'))
		{
			window.open('http://www.iespell.com/download.php');
		}
	}
}
// 粗体
function FTB_Bold(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	FTB_Format(editor,htmlmode,'bold');
}
// 斜体
function FTB_Italic(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	FTB_Format(editor,htmlmode,'italic');
}
// 下划线
function FTB_Underline(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	FTB_Format(editor,htmlmode,'underline');
}
// 删除线
function FTB_Strikethrough(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	FTB_Format(editor,htmlmode,'strikethrough');
}
// 上标
function FTB_Superscript(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	FTB_Format(editor,htmlmode,'superscript');
}
// 下标
function FTB_Subscript(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	FTB_Format(editor,htmlmode,'subscript');
}
// 删除字体格式
function FTB_RemoveFormat(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	FTB_Format(editor,htmlmode,'removeFormat');
}
// 左对齐
function FTB_JustifyLeft(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	FTB_Format(editor,htmlmode,'justifyleft');
}
// 右对齐
function FTB_JustifyRight(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	FTB_Format(editor,htmlmode,'justifyright');
}
// 居中对齐
function FTB_JustifyCenter(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	FTB_Format(editor,htmlmode,'justifycenter');
}
// 两端对齐
function FTB_JustifyFull(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	FTB_Format(editor,htmlmode,'justifyfull');
}
// 项目符号列表
function FTB_BulletedList(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	FTB_Format(editor,htmlmode,'insertunorderedlist');
}
// 数字项目列表
function FTB_NumberedList(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	FTB_Format(editor,htmlmode,'insertorderedlist');
}
// 增加缩进
function FTB_Indent(ftbName,htmlmode) {
	editor = FTB_GetIFrame(ftbName);
	FTB_Format(editor,htmlmode,'indent');
}
// 减少缩进
function FTB_Outdent(ftbName,htmlmode) {
	editor = FTB_GetIFrame(ftbName);
	FTB_Format(editor,htmlmode,'outdent');
}
// 剪切
function FTB_Cut(ftbName,htmlmode) {
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	editor.document.execCommand('cut','',null);
}
// 复制
function FTB_Copy(ftbName,htmlmode) {
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	editor.document.execCommand('copy','',null);
}
// 粘贴
function FTB_Paste(ftbName,htmlmode) {
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	editor.document.execCommand('paste','',null);
}
// 撤销
function FTB_Undo(ftbName,htmlmode) {
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	editor.document.execCommand('undo','',null);
}
// 重复
function FTB_Redo(ftbName,htmlmode) {
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	editor.document.execCommand('redo','',null);
}
// 更改大小写
var changetype = 0;
function FTB_ChangeCase(ftbName,htmlmode) {
	editor = FTB_GetIFrame(ftbName);
	sel = editor.document.selection.createRange();
	txt = sel.htmlText;

	if(txt != '') {
		splitwords = txt.split(' ');
		var f = '';

		for (var i=0; i<splitwords.length;i++) {
			//alert('changing: ' + splitwords[i]);
			switch (changetype) {
				case 0:
					f += splitwords[i].toUpperCase();
					break;
				case 1:
					f += splitwords[i].toLowerCase();
					break;
				case 2:
					tot = splitwords[i].length;
					if (tot > 1) {
						//alert(splitwords[i].substring(1,2).toLowerCase());
						f += splitwords[i].substring(0,1).toUpperCase() + splitwords[i].substring(1,splitwords[i].length).toLowerCase();
					} else {
						f += splitwords[i].toUpperCase();
					}
					break;
			}
			if (i <(splitwords.length-1)) f += ' ';
		}
		sel.pasteHTML(f);
		sel = editor.document.selection.createRange();
		sel.findText(f);
		sel.select();

		editor.focus();

		changetype++;
		if (changetype > 2) changetype = 0;
	}
}
// 清空
function FTB_Delete(ftbName,htmlmode) {
	editor = FTB_GetIFrame(ftbName);
	if (confirm('确实要删除编辑器中所有的文字和 HTML 代码吗？')) {
		editor.document.body.innerHTML = '';
		editor.document.body.innerText = '';
	}
	editor.focus();
}
// 建立超链接
function FTB_CreateLink(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	editor.document.execCommand('createlink','1',null);
}
// 去除超链接
function FTB_Unlink(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	editor.document.execCommand('unlink','1',null);
}
// 插入水平线
function FTB_InsertRule(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	FTB_Format(editor,htmlmode,'inserthorizontalrule');
}
// 插入日期
function FTB_InsertDate(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	var d = new Date();
	sel = editor.document.selection.createRange();
	sel.pasteHTML(d.toLocaleDateString());
}
// 插入时间
function FTB_InsertTime(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	var d = new Date();
	sel = editor.document.selection.createRange();
	sel.pasteHTML(d.toLocaleTimeString());
}
// 字数统计
function FTB_WordCount(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	var iSumWords = 0;
	var rng = editor.document.body.createTextRange();
	var textvalue = editor.document.body.innerText;
	var htmlvalue = editor.document.body.innerHTML;
	rng.collapse(true);
	while(rng.move('word',1)) {
		iSumWords++;
	}
	alert('纯文本 ' + textvalue.length + ' 字，经转义的HTML ' + htmlvalue.length + ' 字，大约 ' + iSumWords + ' 个单词。');
}
// 清除 Word 格式
function FTB_WordClean(ftbName,htmlmode) {
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	// 0bject based cleaning
	var body = editor.document.body;
	for (var index = 0; index < body.all.length; index++) {
		tag = body.all[index];
		//if (tag.Attribute['className'].indexOf('mso') > -1)
		tag.removeAttribute('className','',0);
		tag.removeAttribute('style','',0);
	}

	// Regex based cleaning
	var html = editor.document.body.innerHTML;
	html = html.replace(/<o:p>&nbsp;<\/o:p>/g, '');
	html = html.replace(/o:/g, '');
	html = html.replace(/<st1:.*?>/g, '');

	// Final clean up of empty tags
	html = html.replace(/<font>/g, '');
	html = html.replace(/<span>/g, '');

	editor.document.body.innerHTML = html;
}

/******** 插入表格 Start ********/
function FTB_InsertTable(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();

	var TableFilePath = FTB_FilesPath + 'Support/Table.htm';
	tableArr = showModalDialog(TableFilePath,window,'dialogWidth:300px;dialogHeight:220px;center=yes;resizable=no;help=no;status=no');

	if (tableArr != null) {
		var newTable = editor.document.createElement('TABLE');
		for(y = 0; y < tableArr['rows']; y++) {
			var newRow = newTable.insertRow();
			for(x = 0; x < tableArr['cols']; x++) {
				var newCell = newRow.insertCell();
				if (tableArr['align'] != '') {
					newCell.align = tableArr['align'];
				}
			}
		}
		newTable.border = tableArr['border'];
		newTable.cellspacing = tableArr['cellspacing'];
		newTable.cellpadding = tableArr['cellpadding'];
		newTable.width = tableArr['width'];

		if (editor.document.selection.type=='Control') {
			sel.pasteHTML(newTable.outerHTML);
		} else {
			sel = editor.document.selection.createRange();
			sel.pasteHTML(newTable.outerHTML);
		}
	} else {
		// return false;
	}
}
/******** 插入表格 End ********/

/******** 插入图片 Start ********/
function FTB_InsertImage(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();

	var ImageFilePath = FTB_FilesPath + 'Support/Image.htm';
	imageArr = showModalDialog(ImageFilePath,window,'dialogWidth:340px;dialogHeight:200px;center=yes;resizable=no;help=no;status=no');

	if (imageArr != null) {
		var newImage = editor.document.createElement('IMG');
		newImage.border = 0;
		imageArr['src'] = imageArr['src'].substring(0,6).toLowerCase() == 'upload' ? FTB_FilesPath + imageArr['src'] : imageArr['src'];
		newImage.src = imageArr['src'];
		if (imageArr['align'] != '') newImage.align = imageArr['align'];
		newImage.alt = imageArr['alt'];
		if (imageArr['width'] != '') newImage.width = imageArr['width'];
		if (imageArr['height'] != '') newImage.height = imageArr['height'];
		if (editor.document.selection.type == 'Control') {
			sel.pasteHTML(newImage.outerHTML);
		} else {
			sel = editor.document.selection.createRange();
			sel.pasteHTML(newImage.outerHTML);
		}
	} else {
		// return false;
	}
}
/******** 插入图片 End ********/

/******** 插入代码 Start ********/
function FTB_InsertCode(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();

	var CodeFilePath = FTB_FilesPath + 'Support/Code.htm';
	var LightCode = showModalDialog(CodeFilePath,window,'dialogWidth=560px;dialogHeight=500px;center=yes;resizable=no;help=no;status=no');

	if (LightCode != null) {
		if (editor.document.selection.type=='Control') {
			sel.pasteHTML(LightCode);
		} else {
			sel = editor.document.selection.createRange();
			sel.pasteHTML(LightCode);
		}
	} else {
		// return false;
	}
}
/******** 插入代码 End ********/

/******** 预览 Start********/
function FTB_Preview(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	var values = editor.document.body.innerHTML;

	msg = open('','DisplayWindow','');
	msg.document.body.innerHTML = '';
	msg.document.write('\
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">\r\n\
<html xmlns="http://www.w3.org/1999/xhtml">\r\n\
<head>\r\n\
	<title>荒野新闻系统</title>\r\n\
	<meta content="text/html; charset=gb2312" http-equiv="content-type">\r\n\
	<style type="text/css">\r\n\
		body { background: menu; }\r\n\
		td,body,select,div,span,button { font-size: 14px; font-family: arial; }\r\n\
		button {width: 5em; border-width: 1pt; }\r\n\
		input { border: 1pt solid black; font-size: 12px; padding: 1pt 3pt; }\r\n\
		a:link { color: #0000bb; }\r\n\
		a:visited { color: #0000bb; }\r\n\
	</style>\r\n\
</head>\r\n\
<body>\r\n\
	<h4 style="color: Blue; font-family: 楷体_GB2312; width: 100%; text-align: center">荒野新闻系统</h4>\r\n' + values + '\r\n\
</body>\r\n\
</html>');
}
/******** 预览 End ********/

// 全选
function FTB_SelectAll(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	range = editor.document.body.createTextRange();
	range.select();
}
// 打印
function FTB_Print(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.document.execCommand('print','',null);
}

/******** 插入表单元素 Start ********/
function FTB_InsertInputText(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	editor.document.execCommand('InsertInputText');
}
function FTB_InsertTextArea(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	editor.document.execCommand('InsertTextArea');
}
function FTB_InsertInputRadio(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	editor.document.execCommand('InsertInputRadio');
}
function FTB_InsertInputCheckbox(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	editor.document.execCommand('InsertInputCheckbox');
}
function FTB_InsertInputButton(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	editor.document.execCommand('InsertInputButton');
}
function FTB_InsertMarquee(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	editor.document.execCommand('InsertMarquee');
}
/******** 插入表单元素 End ********/

/******** 插入媒体文件 Start ********/
function FTB_InsertFlash(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();

	var FlashFilePath = FTB_FilesPath + 'Support/Flash.htm';
	imageArr = showModalDialog(FlashFilePath,window,'dialogWidth:320px;dialogHeight:180px;center=yes;resizable=no;help=no;status=no');

	if (imageArr != null) {
		var newImage = editor.document.createElement('IMG');
		newImage.src = FTB_FilesPath + 'images/Flash.GIF';
		imageArr['url'] = imageArr['url'].substring(0,6).toLowerCase() == 'upload' ? FTB_FilesPath + imageArr['url'] : imageArr['url'];
		newImage.alt = '[Flash=' + imageArr['url'] + ']';
		newImage.width = imageArr['width'];
		newImage.height = imageArr['height'];

		if (editor.document.selection.type=='Control') {
			sel.pasteHTML(newImage.outerHTML);
		} else {
			sel = editor.document.selection.createRange();
			sel.pasteHTML(newImage.outerHTML);
		}
	} else {
		// return false;
	}
}
function FTB_InsertWMV(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();

	var WMVFilePath = FTB_FilesPath + 'Support/WMV.htm';
	imageArr = showModalDialog(WMVFilePath,window,'dialogWidth:320px;dialogHeight:180px;center=yes;resizable=no;help=no;status=no');

	if (imageArr != null) {
		var newImage = editor.document.createElement('IMG');
		newImage.src = FTB_FilesPath + 'images/MediaVideo.GIF';
		imageArr['url'] = imageArr['url'].substring(0,6).toLowerCase() == 'upload' ? FTB_FilesPath + imageArr['url'] : imageArr['url'];
		newImage.alt = '[WMV=' + imageArr['url'] + ']';
		newImage.width = imageArr['width'];
		newImage.height = imageArr['height'];

		if (editor.document.selection.type=='Control') {
			sel.pasteHTML(newImage.outerHTML);
		} else {
			sel = editor.document.selection.createRange();
			sel.pasteHTML(newImage.outerHTML);
		}
	} else {
		// return false;
	}
}
function FTB_InsertWMA(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	var inputUrl = prompt('请输入Windows Media Player音频文件地址：', 'http://');
	if (inputUrl != null && inputUrl != '' && inputUrl != 'undefined' && inputUrl != 'http://') {
		editor.focus();
		var newImage = editor.document.createElement('IMG');
		newImage.src = FTB_FilesPath + 'images/MediaAudio.GIF';
		inputUrl = inputUrl.substring(0,6).toLowerCase() == 'upload' ? FTB_FilesPath + inputUrl : inputUrl;
		newImage.alt = '[WMA=' + inputUrl + ']';

		if (editor.document.selection.type=='Control') {
			sel.pasteHTML(newImage.outerHTML);
		} else {
			sel = editor.document.selection.createRange();
			sel.pasteHTML(newImage.outerHTML);
		}
	}
}
function FTB_InsertRM(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();

	var RMFilePath = FTB_FilesPath + 'Support/RM.htm';
	imageArr = showModalDialog(RMFilePath,window,'dialogWidth:320px;dialogHeight:180px;center=yes;resizable=no;help=no;status=no');

	if (imageArr != null) {
		var newImage = editor.document.createElement('IMG');
		newImage.src = FTB_FilesPath + 'images/RealMedia.GIF';
		imageArr['url'] = imageArr['url'].substring(0,6).toLowerCase() == 'upload' ? FTB_FilesPath + imageArr['url'] : imageArr['url'];
		newImage.alt = '[RM=' + imageArr['url'] + ']';
		newImage.width = imageArr['width'];
		newImage.height = imageArr['height'];

		if (editor.document.selection.type=='Control') {
			sel.pasteHTML(newImage.outerHTML);
		} else {
			sel = editor.document.selection.createRange();
			sel.pasteHTML(newImage.outerHTML);
		}
	} else {
		// return false;
	}
}
function FTB_InsertRA(ftbName,htmlmode) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	var inputUrl = prompt('请输入RealPlayer音频文件地址：', 'http://');
	if (inputUrl != null && inputUrl != '' && inputUrl != 'undefined' && inputUrl != 'http://') {
		editor.focus();
		var newImage = editor.document.createElement('IMG');
		newImage.src = FTB_FilesPath + 'images/RealAudio.GIF';
		inputUrl = inputUrl.substring(0,6).toLowerCase() == 'upload' ? FTB_FilesPath + inputUrl : inputUrl;
		newImage.alt = '[RA=' + inputUrl + ']';

		if (editor.document.selection.type=='Control') {
			sel.pasteHTML(newImage.outerHTML);
		} else {
			sel = editor.document.selection.createRange();
			sel.pasteHTML(newImage.outerHTML);
		}
	}
}
/******** 插入媒体文件 End ********/

/******** 下拉菜单 Start ********/
// 字体
function FTB_SetFontFace(ftbName,htmlmode,name,value) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	value = value == 'Times' ? 'Times New Roman' : value;
	editor.focus();
	editor.document.execCommand('fontname','',value);
}
// 字号
function FTB_SetFontSize(ftbName,htmlmode,name,value) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	editor.document.execCommand('fontsize','',value);
}
// 字体颜色
function FTB_SetFontForeColor(ftbName,htmlmode,name,value) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	editor.document.execCommand('forecolor','',value);
}
// 背景颜色
function FTB_SetFontBackColor(ftbName,htmlmode,name,value) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	editor.document.execCommand('backcolor','',value);
}

/******** 样式 Start ********/
function FTB_SetStyle(ftbName,htmlmode,name,value) {
	editor = FTB_GetIFrame(ftbName);
	if (value == '[Remove Style]') {
		if (editor.document.selection.type == 'Control') {
			var oControlRange = editor.document.selection.createRange();
			var oControlItem = oControlRange.item(0);
			var oTextRange = editor.document.body.createTextRange();
			oTextRange.moveToElementText(oControlItem);
			oTextRange.select();
			var sHTML = oTextRange.htmlText;
			sHTML = sHTML.replace(/<SPAN[^>]*>([\s\S]*?)<\/SPAN>/ig, '<FONT face=ftb_removestyle>$1</FONT>');
			oTextRange.pasteHTML(sHTML);
		} else {
			var oRange = editor.document.selection.createRange();
			oRange.execCommand('FontName', false, 'ftb_removestyle');
		}
		FTB_RemoveStyle(editor.document.body);
		FTB_RemoveStyleClean(editor.document.body);
	} else {
		if (editor.document.selection.type == 'Control') {
			var oControlRange = editor.document.selection.createRange();
			var oControlItem = oControlRange.item(0);
			var oTextRange = editor.document.body.createTextRange();
			oTextRange.moveToElementText(oControlItem);
			oTextRange.select();
			var sHTML = oTextRange.htmlText;
			sHTML = sHTML.replace(/<SPAN[^>]*>([\s\S]*?)<\/SPAN>/ig, '$1'); oTextRange.pasteHTML('<FONT face=ftb_span>' + sHTML + '</FONT>');
		} else {
			var oRange = editor.document.selection.createRange();
			var sBookmark = oRange.getBookmark();
			var sHTML = oRange.htmlText;
			sHTML = sHTML.replace(/class=\w*/ig,'');
			oRange.pasteHTML(sHTML);
			oRange.moveToBookmark(sBookmark);
			oRange.execCommand('FontName', false, 'ftb_span');
		}
		FTB_FontsToSpans(editor.document, editor.document.body, value);
		FTB_JoinSpans(editor.document.body, null);
		FTB_RemoveEmptySpans(editor.document.body);
	}
}
function FTB_RemoveStyle(oElement) {
	for(var i = 0;i < oElement.childNodes.length; i++) {
		FTB_RemoveStyle(oElement.childNodes[i]);
	}
	if(oElement.tagName == 'SPAN') {
		if(oElement.innerHTML.indexOf('ftb_removestyle') != -1) {
			oElement.removeNode(false);
		}
	}
}
function FTB_RemoveStyleClean(oElement) {
	for(var i = 0;i < oElement.childNodes.length; i++) {
		FTB_RemoveStyleClean(oElement.childNodes[i]);
	}
	if(oElement.tagName == 'FONT') {
		if(oElement.face == 'ftb_removestyle') {
			oElement.removeNode(false);
		}
	}
}
function FTB_FontsToSpans(oDocument, oElement, sClass) {
	for(var i = 0;i < oElement.childNodes.length; i++) {
		FTB_FontsToSpans(oDocument, oElement.childNodes[i], sClass);
	}
	if(oElement.tagName == 'FONT') {
		if(oElement.face == 'ftb_span') {
			sPreserve = oElement.innerHTML;
			oSpan = oDocument.createElement('SPAN');
			oElement.replaceNode(oSpan);
			oSpan.innerHTML = sPreserve;
			oSpan.className = sClass;
		} else {
			var sStyle = '';
			if (oElement.face.length) {
				sStyle += 'font-family: ' + oElement.face + ';';
			}
			if (oElement.size.length) {
				var sSize = oElement.size;
				if (sSize == '1') sSize = 'xx-small';
				if (sSize == '2') sSize = 'x-small';
				if (sSize == '3') sSize = 'small';
				if (sSize == '4') sSize = 'medium';
				if (sSize == '5') sSize = 'large';
				if (sSize == '6') sSize = 'x-large';
				if (sSize == '7') sSize = 'xx-large';
				if (sSize.substring(0, 1) == '-') sSize = 'smaller';
				if (sSize.substring(0, 1) == '+') sSize = 'larger';
				sStyle += 'font-size: ' + sSize + ';';
			}
			if (oElement.color.length) {
				sStyle += 'color: ' + oElement.color + ';';
			}
			if (sStyle.length) {
				sPreserve = oElement.innerHTML;
				oSpan = oDocument.createElement('SPAN');
				oElement.replaceNode(oSpan);
				oSpan.innerHTML = sPreserve;
				oSpan.style.cssText = sStyle;
			}
		}
	}
}
function FTB_JoinSpans(oElement, oParent) {
	for(var i = 0;i < oElement.childNodes.length; i++) {
		var oChild = oElement.childNodes[i];
		oElement = FTB_JoinSpans(oChild, oElement);
	}
	if (oElement.tagName == 'SPAN' && oParent != null && oParent.tagName == 'SPAN') {
		if (oElement.innerText == oParent.innerText) {
			sElementClass = oElement.className;
			sParentClass = oParent.className;
			if(sParentClass.length && !sElementClass.length) {
				oElement.setAttribute('class', sParentClass);
			}
			var parentAttributes = oParent.style.cssText.split('; ');
			var elementAttributes = oElement.style.cssText.split('; ');
			for (var i = 0;i < parentAttributes.length; i++) {
				var parentPairs = parentAttributes[i].split(':');
				var sPKey = parentPairs[0];
				var sPValue = parentPairs[1];
				var bKeyExists = false;
				for (var k = 0;k < elementAttributes.length; k++) {
					var elementPairs = elementAttributes[k].split(':');
					var sEKey = elementPairs[0];
					var sEValue = elementPairs[1];
					if (sEKey == sPKey) {
						bKeyExists = true; break;
					}
				}
				if (!bKeyExists) {
					oElement.style.cssText = oElement.style.cssText + ';' + sPKey + ':' + sPValue;
				}
			}
			oParent.removeNode(false);
			return oElement;
		}
	}
	return oParent;
}
function FTB_RemoveEmptySpans(oElement) {
	for(var i = 0;i < oElement.childNodes.length; i++) {
		FTB_RemoveEmptySpans(oElement.childNodes[i]);
	}
	if (oElement.tagName == 'SPAN' && oElement.className.length == 0 && oElement.style.cssText == '') {
		oElement.removeNode(false);
	}
}
/******** 样式 End ********/

// 插入 HTML
function FTB_InsertHtml(ftbName,htmlmode,name,value) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	sel = editor.document.selection.createRange();
	sel.pasteHTML(value);
}
// 插入符号
function FTB_InsertSymbol(ftbName,htmlmode,name,value) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	sel = editor.document.selection.createRange();
	sel.pasteHTML(value);
}
// 段落格式
function FTB_SetParagraph(ftbName,htmlmode,name,value) {
	if (htmlmode) return;
	editor = FTB_GetIFrame(ftbName);
	editor.focus();
	if (value == '<body>') {
		editor.document.execCommand('formatBlock','','Normal');
		editor.document.execCommand('removeFormat');
		return;
	}
	editor.document.execCommand('formatBlock','',value);
}
/******** 下拉菜单 End ********/
/******** ToolbarItems End ********/
// -->