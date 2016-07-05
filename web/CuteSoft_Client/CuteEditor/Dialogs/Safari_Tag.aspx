<%@ Page Language="C#" Inherits="CuteEditor.EditorUtilityPage" %>
<%@ Import Namespace="System.Xml"%>
<script runat="server">
public bool IsTagPattern(string tagname,string pattern)
{
	if(pattern=="*")return true;
	tagname=tagname.ToLower();
	pattern=pattern.ToLower();
	if(tagname==pattern)return true;
	foreach(string str in pattern.Split(",;|/".ToCharArray()))
	{
		if(str=="*")return true;
		if(str==tagname)return true;
		if(str=="-"+tagname)return false;
	}
	return false;
}
public string GetTagDisplayName(string tagname)
{
	switch(tagname.ToLower())
	{
		case "img":
			return "[[Image]]";
		case "object":
			return "[[ActiveXObject]]";
		case "table":
		case "inserttable":
			return "[["+tagname+"]]";
		default:
			return tagname;
	}
}
bool nocancel=false;
</script>
<%
	if(Context.Request.QueryString["NoCancel"]=="True")
		nocancel=true;
		
	string tagName=Context.Request.QueryString["Tag"];
	string tabName=Context.Request.QueryString["Tab"];
	XmlDocument doc=new XmlDocument();
	doc.Load(Server.MapPath("Gecko_tag.config"));
	string tabcontrol=null;
	string tabtext="";
%>
<html>
	<title>
		[[Properties]] 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	</title>		
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)">
	<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)">
	<link rel="stylesheet" href='Safari_style.css'>
	<script src=Safari_dialog.js></script>
	<%if(nocancel){%>
	<script>
	var OxO776e=[];var nocancel=true;
	</script>
	<%}else{%>
	<script>
	var OxObaf4=[];var nocancel=false;
	</script>
	<%}%>
	
	<script>
	var OxOac50=["dialogArguments","opener","element","editor","window","document","availWidth","availHeight",""];var arg=window[OxOac50[0x1]][OxOac50[0x0]];var element=arg[OxOac50[0x2]];var editor=arg[OxOac50[0x3]];var editwin=arg[OxOac50[0x4]];var editdoc=arg[OxOac50[0x5]]; window.focus() ; window.moveTo((screen[OxOac50[0x6]]-0x258)/0x2,(screen[OxOac50[0x7]]-0x190)/0x2) ; function ParseToString(Ox1f){var Ox9=parseFloat(Ox1f);if(isNaN(Ox9)){return OxOac50[0x8];} ;return Ox9+OxOac50[0x8];}  ; function UpdateState(){}  ; function SyncTo(){}  ; function SyncToView(){}  ;
	</script>
	<body style="border-width:0px;padding-top:4px;padding-left:4px;padding-right:4px;;margin:0px;">
		<span style='font-size:12pt;font-weight:bold;TEXT-TRANSFORM: capitalize;'>
			<%=GetTagDisplayName(tagName)%>
		</span>
			<div id="controlparent" style="padding:10px">
			<table>
					<tr>
						<td id="menu">
						<%
							int index=0;
							foreach(XmlElement xe in doc.DocumentElement.SelectNodes("add"))
							{
								string tab=xe.GetAttribute("tab");
						
								if(IsTagPattern(tagName,xe.GetAttribute("pattern")))
								{
									bool isactive=(index==0&&(tabName==null||tabName==""))||(string.Compare(tab,tabName,true)==0);
									if(isactive)
									{
										tabcontrol=xe.GetAttribute("control");
										tabtext=xe.GetAttribute("text");
									}
									index++;
								}
							}	
						%>
						</td>
					</tr>
				</table>
				<br>
			<%
				if(tabcontrol!=null)
				{
					try
					{
						Control ctrl=LoadControl("Tag//Safari_"+tabcontrol);
						holder1.Controls.Add(ctrl);
					}
					catch(Exception x)
					{
						if(Context.Request.QueryString["_err"]=="2")
							throw;
						%>
			<iframe style="width:378;height:333" src='<%=Context.Request.RawUrl+"&_err=2"%>'></iframe>
			<%
					}
				}
			%>
			<asp:PlaceHolder ID="holder1" Runat="server"></asp:PlaceHolder>
		<div style="text-align:right;padding-top:8px;padding-bottom:2px;padding-right:12px;">		
			<input type="button" id="btn_editinwin" value="[[EditHtml]]" style="width:80px" onclick="btn_editinwin_onclick()">&nbsp;&nbsp;&nbsp;
			<input type="button" id="btnok" value="[[OK]]" style="width:80px" onclick="btnok_onclick()">&nbsp;
			<input type="button" id="btncc" value="[[Cancel]]" style="width:80px" onclick="btncc_onclick()">
		</div>
		</div>
	</body>
	<script>
	
	var OxOd4f2=["btn_editinwin","btncc","btnok","controlparent","availWidth","availHeight","display","style","none","innerHTML","","ESC()","onkeydown","keyCode","returnValue","propertyName","value","checked","attachEvent","on","addEventListener","which","preventDefault"];var btn_editinwin=document.getElementById(OxOd4f2[0x0]);var btncc=document.getElementById(OxOd4f2[0x1]);var btnok=document.getElementById(OxOd4f2[0x2]);var controlparent=document.getElementById(OxOd4f2[0x3]); window.moveTo((screen[OxOd4f2[0x4]]-0x258)/0x2,(screen[OxOd4f2[0x5]]-0x190)/0x2) ; btn_editinwin[OxOd4f2[0x7]][OxOd4f2[0x6]]=OxOd4f2[0x8] ; function btn_editinwin_onclick(){var Oxb0=editor.EditInWindow(element.innerHTML,window);if(Oxb0!=null&&Oxb0!=false){ element[OxOd4f2[0x9]]=Oxb0 ;} ;}  ; AttachDomEvent(document,OxOd4f2[0xc], new Function(OxOd4f2[0xa],OxOd4f2[0xb])) ; function ESC(){if(event[OxOd4f2[0xd]]==0x1b){ top[OxOd4f2[0xe]]=false ; top.close() ;} ;}  ; function btnok_onclick(){ SyncTo() ; top.close() ;}  ; function btncc_onclick(){ top.close() ;}  ;if(nocancel){ btncc[OxOd4f2[0x7]][OxOd4f2[0x6]]=OxOd4f2[0x8] ;} ;var syncingtoview=false; SyncToViewInternal() ; setInterval(UpdateState,0x12c) ; function OnPropertyChange(Ox551){if(syncingtoview){return ;} ;if(event[OxOd4f2[0xf]]!=OxOd4f2[0x10]&&event[OxOd4f2[0xf]]!=OxOd4f2[0x11]){return ;} ; FireUIChanged() ;}  ; function FireUIChanged(){}  ; function SyncToViewInternal(){ syncingtoview=true ;try{ SyncToView() ; UpdateState() ;} finally{ syncingtoview=false ;} ;}  ; function AttachDomEvent(obj,name,Ox1d6){if(obj[OxOd4f2[0x12]]){ obj.attachEvent(OxOd4f2[0x13]+name,Ox1d6) ;} ;if(obj[OxOd4f2[0x14]]){ obj.addEventListener(name,Ox1d6,true) ;} ;}  ; function IsDigit(e){var Ox17c=e[OxOd4f2[0xd]]||e[OxOd4f2[0x15]];if((Ox17c<0x30||Ox17c>0x39)&&Ox17c!=0x8&&(Ox17c<0x23||Ox17c>0x25)&&Ox17c!=0x27&&Ox17c!=0x2e){if(e[OxOd4f2[0x16]]){ e.preventDefault() ;} ;return false; e[OxOd4f2[0xd]]=0x0 ;} ;}  ; function SelectColor(Ox5cc,Ox19b){var Ox354= new ColorPicker(Ox19b,Ox5cc); Ox354.showPopup() ;}  ;
	
	</script>
</html>

