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
	doc.Load(Server.MapPath("tag.config"));
	string tabcontrol=null;
	string tabtext="";
%>
<html>
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)">
	<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)">
	<link rel="stylesheet" href='style.css'>
	<script src=dialog.js></script><script src=../_shared.js></script>
	<%if(nocancel){%>
	<script>
	var OxO6850=[];var nocancel=true;
	</script>
	<%}else{%>
	<script>
	var OxO3341=[];var nocancel=false;
	</script>
	<%}%>
	<script>
	var OxO4d38=["dialogArguments","element","editor","window","document","BaseHref","UseRelativeLinks","nocancel","changed",""];var arg=top[OxO4d38[0x0]];var element=arg[OxO4d38[0x1]];var editor=arg[OxO4d38[0x2]];var editwin=arg[OxO4d38[0x3]];var editdoc=arg[OxO4d38[0x4]];var BaseHref=arg[OxO4d38[0x5]];var UseRelativeLinks=arg[OxO4d38[0x6]]; top[OxO4d38[0x7]]=nocancel ; top[OxO4d38[0x8]]=top[OxO4d38[0x8]]||arg[OxO4d38[0x8]] ; function ParseToString(Ox1f){var Ox9=parseFloat(Ox1f);if(isNaN(Ox9)){return OxO4d38[0x9];} ;return Ox9+OxO4d38[0x9];}  ; function UpdateState(){}  ; function SyncTo(element){}  ; function SyncToView(){}  ;
	</script>
	<body style="border-width:0px;padding-top:4px;padding-left:4px;padding-right:4px;;margin:0px;">
		<span style='font-size:12pt;font-weight:bold;TEXT-TRANSFORM: capitalize;'>
			<%=GetTagDisplayName(tagName)%>
		</span>
		<fieldset id="controlparent" style="width:100%; height:386px; padding-left:7px; padding-right:7px; padding-bottom:7px;">
			<legend align="right">
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
						%>
							<a class='<%=isactive?"ActiveTabNav":"TabNav"%>' tabindex="-1" href='<%=CuteEditor.EditorUtility.ReplaceParam(Request.RawUrl,"Tab",tab)%>'>
								<%=xe.GetAttribute("text")%>
							</a>
							<%
							index++;
						}
					}	
					%>
						</td>
					</tr>
				</table>
			</legend>
			<%
				if(tabcontrol!=null)
				{
					try
					{
						Control ctrl=LoadControl("Tag//"+tabcontrol);
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
		</fieldset>
		<div style="text-align:right;padding-top:8px;padding-bottom:2px;padding-right:12px;">
		
			<button id="btn_editinwin">[[EditHtml]]</button>
			&nbsp;&nbsp;&nbsp;
			<button id="btnok" style='width:80px'>[[OK]]</button>&nbsp;
			<button id="btncc" style='width:80px'>[[Cancel]]</button>
		</div>
	</body>
	<script>
	
	var OxOddb3=["display","style","none","innerHTML","onkeydown","keyCode","returnValue","all","length","skipAutoFireChanged","isnotinput","1","tagName","SELECT","INPUT","TEXTAREA","","OnPropertyChange(this)","onpropertychange","if(!syncingtoview)FireUIChanged()","onchange","onkeypress","onkeyup","propertyName","value","checked","changed","[[ValidNumber]]"]; btn_editinwin[OxOddb3[0x1]][OxOddb3[0x0]]=OxOddb3[0x2] ; function btn_editinwin.onclick(){var Oxb0=editor.EditInWindow(element.innerHTML,window);if(Oxb0!=null&&Oxb0!=false){ element[OxOddb3[0x3]]=Oxb0 ;} ;}  ; document.attachEvent(OxOddb3[0x4],function (){if(event[OxOddb3[0x5]]==0x1b){ top[OxOddb3[0x6]]=false ; top.close() ;} ;} ) ; function btnok.onclick(){ top[OxOddb3[0x6]]=true ; top.close() ;}  ; function btncc.onclick(){ top[OxOddb3[0x6]]=false ; top.close() ;}  ;if(nocancel){ btncc[OxOddb3[0x1]][OxOddb3[0x0]]=OxOddb3[0x2] ;} ;var syncingtoview=false;var coll=controlparent[OxOddb3[0x7]];for(var i=0x0;i<coll[OxOddb3[0x8]];i++){var e=coll[i];if(e[OxOddb3[0xa]]==OxOddb3[0xb]||e.getAttribute(OxOddb3[0x9])){continue ;} ;if(e[OxOddb3[0xc]]==OxOddb3[0xd]||e[OxOddb3[0xc]]==OxOddb3[0xe]||e[OxOddb3[0xc]]==OxOddb3[0xf]){ e.attachEvent(OxOddb3[0x12], new Function(OxOddb3[0x10],OxOddb3[0x11])) ; e.attachEvent(OxOddb3[0x14], new Function(OxOddb3[0x10],OxOddb3[0x13])) ; e.attachEvent(OxOddb3[0x15], new Function(OxOddb3[0x10],OxOddb3[0x13])) ; e.attachEvent(OxOddb3[0x16], new Function(OxOddb3[0x10],OxOddb3[0x13])) ;} ;} ; SyncToViewInternal() ; setInterval(UpdateState,0x12c) ; function OnPropertyChange(Ox551){if(syncingtoview){return ;} ;if(event[OxOddb3[0x17]]!=OxOddb3[0x18]&&event[OxOddb3[0x17]]!=OxOddb3[0x19]){return ;} ; FireUIChanged() ;}  ; function FireUIChanged(){ top[OxOddb3[0x1a]]=true ; SyncTo(element) ; UpdateState() ;}  ; function SyncToViewInternal(){ syncingtoview=true ;try{ SyncToView() ; UpdateState() ;} finally{ syncingtoview=false ;} ;}  ; function IsDigit(){if((event[OxOddb3[0x5]]>=0x30)&&(event[OxOddb3[0x5]]<=0x39)){return true;} else { alert(OxOddb3[0x1b]) ;return false;} ;}  ;
	</script>
</html>

