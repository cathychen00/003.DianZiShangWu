<%@ Control Inherits="CuteEditor.EditorUtilityCtrl" Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<fieldset><legend>[[Input]]</legend>
	<table class="normal">
		<tr>
			<td style='width:60px'>[[Name]]:</td>
			<td><input type="text" id="inp_name" style="width:100px"></td>
			<td style='width:60px'>[[ID]]:</td>
			<td><input type="text" id="inp_id" style="width:100px"></td>
		</td>
	</table>
	<table class="normal">
		<tr>
			<td style='width:60px'>[[Type]]:</td>
			<td><input type="text" id="inp_type" readonly="true" disabled="true" style="width:100px"></td>
			<td style='width:60px'><label for="inp_checked">[[Checked]]</label>:</td>
			<td><input type="checkbox" id="inp_checked"><label for="inp_checked">[[Checked]]</label></td>
		</td>
	</table>
	<table class="normal">
		<tr>
			<td style='width:60px'>[[Value]]:</td>
			<td><input type="text" id="inp_value" style="width:268px"></td>
			<td></td>
		</tr>
	</table>
	<table class="normal">
		<tr>
			<td style='width:60px'>[[CssClass]]:</td>
			<td><input type="text" id="inp_class" style="width:268px"></td>
			<td></td>
		</tr>
	</table>
</fieldset>

<script src=Gecko_dialog.js></script><script src=../_shared.js></script>

<script>

var OxO3c74=["inp_name","inp_id","inp_type","inp_checked","inp_value","inp_class","name","value","id","type","checked","className"];var inp_name=document.getElementById(OxO3c74[0x0]);var inp_id=document.getElementById(OxO3c74[0x1]);var inp_type=document.getElementById(OxO3c74[0x2]);var inp_checked=document.getElementById(OxO3c74[0x3]);var inp_value=document.getElementById(OxO3c74[0x4]);var inp_class=document.getElementById(OxO3c74[0x5]); function SyncToView(){ inp_name[OxO3c74[0x7]]=element[OxO3c74[0x6]] ; inp_id[OxO3c74[0x7]]=element[OxO3c74[0x8]] ; inp_value[OxO3c74[0x7]]=element[OxO3c74[0x7]] ; inp_type[OxO3c74[0x7]]=element[OxO3c74[0x9]] ; inp_checked[OxO3c74[0xa]]=element[OxO3c74[0xa]] ; inp_class[OxO3c74[0x7]]=element[OxO3c74[0xb]] ;}  ; function SyncTo(){ element[OxO3c74[0x6]]=inp_name[OxO3c74[0x7]] ; element[OxO3c74[0x8]]=inp_id[OxO3c74[0x7]] ;if(inp_value[OxO3c74[0x7]]){ element[OxO3c74[0x7]]=inp_value[OxO3c74[0x7]] ;} ; element[OxO3c74[0xa]]=inp_checked[OxO3c74[0xa]] ;if(inp_class[OxO3c74[0x7]]){ element[OxO3c74[0xb]]=inp_class[OxO3c74[0x7]] ;} ;}  ;

</script>
