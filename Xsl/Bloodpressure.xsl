<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
			         xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" 
			         xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
			         xmlns:navigation="clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Navigation">
			         
	<xsl:output method="xml" indent="yes"/>
	
	<xsl:template match="/">
		<xsl:call-template name="draw-grid">
			<xsl:with-param name="rcount" select="23"/>
			<xsl:with-param name="ccount" select="6"/>
			
		</xsl:call-template>
	</xsl:template>
	
	<xsl:template name="draw-grid">
		<xsl:param name="rcount"/>
		<xsl:param name="ccount"/>
		
		<xsl:element name="navigation:Page" namespace="clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Navigation">
		<xsl:namespace name=""><xsl:text>http://schemas.microsoft.com/winfx/2006/xaml/presentation</xsl:text></xsl:namespace>
			<xsl:attribute name="Title">Bloodpressure</xsl:attribute>
			<xsl:attribute name="x:Class">SilverlightCSharp.Bloodpressure</xsl:attribute>
			<xsl:attribute name="KeyDown">Page_KeyDown</xsl:attribute>
		
		<xsl:element name="Grid">
			<xsl:attribute name="x:Name"><xsl:text>grid1</xsl:text></xsl:attribute>
			<xsl:attribute name="ShowGridLines">True</xsl:attribute>
			<xsl:element name="Grid.Background">
				<xsl:element name="LinearGradientBrush">
					<xsl:element name="GradientStop">
						<xsl:attribute name="Color">#FF93C5E8</xsl:attribute>
					</xsl:element>
					<xsl:element name="GradientStop">
						<xsl:attribute name="Color">#FF3B596E</xsl:attribute>
						<xsl:attribute name="Offset">1</xsl:attribute>
					</xsl:element>
				</xsl:element>
			</xsl:element>
			
			<!-- Definieer de rijen -->
			<xsl:element name="Grid.RowDefinitions">
				<xsl:call-template name="draw-rows">
					<xsl:with-param name="rcount">
						<xsl:value-of select="$rcount"/>
					</xsl:with-param>
					<xsl:with-param name="r">
						<xsl:value-of select="0"/>
					</xsl:with-param>
				</xsl:call-template>
			</xsl:element>
			
			<!--Definieer de kolommen -->
			<xsl:element name="Grid.ColumnDefinitions">
				<xsl:call-template name="draw-cols">
					<xsl:with-param name="ccount">
						<xsl:value-of select="$ccount"/>
					</xsl:with-param>
					<xsl:with-param name="c">
						<xsl:value-of select="0"/>
					</xsl:with-param>
				</xsl:call-template>
			</xsl:element>
			
			<xsl:call-template name="draw-checkboxes">
				<xsl:with-param name="rcount">
						<xsl:value-of select="$rcount -3"/>
					</xsl:with-param>
					<xsl:with-param name="r">
						<xsl:value-of select="0"/>
					</xsl:with-param>
			</xsl:call-template>
			
			<xsl:element name="Border">
				<xsl:attribute name="Grid.Column">1</xsl:attribute>
				<xsl:attribute name="Grid.Column">1</xsl:attribute>
				<xsl:element name="TextBlock">
					<xsl:attribute name="HorizontalAlignment">Center</xsl:attribute>
					<xsl:attribute name="VerticalAlignment">Center</xsl:attribute>
					<xsl:attribute name="Foreground">Ivory</xsl:attribute>
					<xsl:attribute name="Text" select="//heading"/>
				</xsl:element>
			</xsl:element>
			
			<xsl:element name="Border">
				<xsl:attribute name="Grid.Column">1</xsl:attribute>
				<xsl:attribute name="Grid.Column">3</xsl:attribute>
				<xsl:element name="TextBlock">
					<xsl:attribute name="HorizontalAlignment">Center</xsl:attribute>
					<xsl:attribute name="VerticalAlignment">Center</xsl:attribute>
					<xsl:attribute name="Foreground">Ivory</xsl:attribute>
					<xsl:attribute name="Text" select="//patient"/>
				</xsl:element>
			</xsl:element>
			
			<xsl:call-template name="print-values"/>
			<xsl:call-template name="draw-buttons"/>
			<xsl:call-template name="draw-labels"/>
		</xsl:element>

		</xsl:element>
	</xsl:template>
	
	<!-- Teken de Buttons -->
	<xsl:template name="draw-buttons">
		<xsl:param name="gridcol" select="0"/>
		<xsl:param name="number" select="1"/>
		
		<xsl:element name="Button">
			<xsl:attribute name="VerticalAlignment">Center</xsl:attribute>
			<xsl:attribute name="Height">40</xsl:attribute>
			<xsl:attribute name="Grid.Row" select="1"/>
			<xsl:attribute name="Grid.Column" select="$gridcol"/>
			<xsl:attribute name="x:Name">
				<xsl:choose>
					<xsl:when test="$number = 1">
						<xsl:text>btnGtSystolicLimit</xsl:text>
					</xsl:when>
					<xsl:when test="$number = 2">
						<xsl:text>btnLtDiastolicLimit</xsl:text>
					</xsl:when>
					<xsl:when test="$number = 3">
						<xsl:text>btnValid</xsl:text>
					</xsl:when>
					<xsl:when test="$number = 4">
						<xsl:text>btnLtAverage</xsl:text>
					</xsl:when>
					<xsl:when test="$number = 5">
						<xsl:text>btnGtAverage</xsl:text>
					</xsl:when>
				</xsl:choose>
			</xsl:attribute>
			
<xsl:attribute name="Click">
				<xsl:choose>
					<xsl:when test="$number = 1">
						<xsl:text>btnGtSystolicLimit_Click</xsl:text>
					</xsl:when>
					<xsl:when test="$number = 2">
						<xsl:text>btnLtDiastolicLimit_Click</xsl:text>
					</xsl:when>
					<xsl:when test="$number = 3">
						<xsl:text>btnValid_Click</xsl:text>
					</xsl:when>
					<xsl:when test="$number = 4">
						<xsl:text>btnLtAverage_Click</xsl:text>
					</xsl:when>
					<xsl:when test="$number = 5">
						<xsl:text>btnGtAverage_Click</xsl:text>
					</xsl:when>
				</xsl:choose>
			</xsl:attribute>
			<xsl:choose>
				<xsl:when test="$number = 1">
					<xsl:text>&gt; Systolic Limit: 110</xsl:text>
				</xsl:when>
				<xsl:when test="$number = 2">
					<xsl:text>&lt; Diastolic Limit : 90</xsl:text>
				</xsl:when>
				<xsl:when test="$number = 3">
					<xsl:text>Invalid</xsl:text>
				</xsl:when>
				<xsl:when test="$number = 4">
					<xsl:text>&lt; Average Systolic</xsl:text>
				</xsl:when>
				<xsl:when test="$number = 5">
					<xsl:text>&gt; Average Diastolic</xsl:text>
				</xsl:when>
			</xsl:choose>
		</xsl:element>
		
		<xsl:if test="$number &lt; 5">
			<xsl:call-template name="draw-buttons">
				<xsl:with-param name="gridcol" select="$gridcol + 1"/>
				<xsl:with-param name="number" select="$number + 1"/>
			</xsl:call-template>
		</xsl:if>
	</xsl:template>
	
	<!-- Teken de Labels -->
	<xsl:template name="draw-labels">
		<xsl:param name="gridcol" select="0"/>
		<xsl:param name="number" select="1"/>
		
		<xsl:element name="Border">
	
			<xsl:attribute name="Background">Maroon</xsl:attribute>
	
			<xsl:attribute name="Grid.Row" select="2"/>
			<xsl:attribute name="Grid.Column" select="$gridcol"/>

		
			<xsl:element name="TextBlock">
				<xsl:attribute name="HorizontalAlignment">Center</xsl:attribute>
				<xsl:attribute name="VerticalAlignment">Center</xsl:attribute>
				<xsl:attribute name="Foreground">Ivory</xsl:attribute>
				
				<xsl:choose>
					<xsl:when test="$number = 1">
						<xsl:text>Number</xsl:text>
					</xsl:when>
					<xsl:when test="$number = 2">
						<xsl:text>Date</xsl:text>
					</xsl:when>
					<xsl:when test="$number = 3">
						<xsl:text>Valid</xsl:text>
					</xsl:when>
					<xsl:when test="$number = 4">
						<xsl:text>Systolic Blood Pressure</xsl:text>
					</xsl:when>
					<xsl:when test="$number = 5">
						<xsl:text>Diastolic Blood Pressure</xsl:text>
					</xsl:when>
				</xsl:choose>
			</xsl:element>

		</xsl:element>
		
		<xsl:if test="$number &lt; 5">
			<xsl:call-template name="draw-labels">
				<xsl:with-param name="gridcol" select="$gridcol + 1"/>
				<xsl:with-param name="number" select="$number + 1"/>
			</xsl:call-template>
		</xsl:if>
	</xsl:template>
	
	<!-- Template om de rijen te tekenen -->
	<xsl:template name="draw-rows">
		<xsl:param name="rcount"/>
		<xsl:param name="r"/>
		<xsl:param name="rheight"/>
		
		<!-- Blijf rijen toevoegen zolang $r kleiner is dan de meegegeven parameter $rcount bij aanroep template -->
		<xsl:if test="$r &lt; number($rcount)">
			<xsl:element name="RowDefinition">
				<xsl:choose>
					<xsl:when test="number($r) &lt; 3">
						<xsl:attribute name="Height">1.38*</xsl:attribute>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="Height">*</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>	
			</xsl:element>
		</xsl:if>
		<xsl:if test="$r &lt; number($rcount)">
			<xsl:call-template name="draw-rows">
				<xsl:with-param name="r">
					<xsl:value-of select="$r  + 1"/>
				</xsl:with-param>
				<xsl:with-param name="rcount">
					<xsl:value-of select="$rcount"/>
				</xsl:with-param>
			</xsl:call-template>
		</xsl:if>

	</xsl:template>
	
	<!-- Template om de kolommen te tekenen -->
	<xsl:template name="draw-cols">
		<xsl:param name="ccount"/>
		<xsl:param name="c"/>
		
		<!-- Blijf kolommen toevoegen zolang $c kleiner is dan de meegegeven parameter $ccount bij aanroep template -->
		<xsl:if test="$c &lt; number($ccount)">
			<xsl:element name="ColumnDefinition">
				<xsl:attribute name="Width">*</xsl:attribute>
			</xsl:element>
		</xsl:if>
		<xsl:if test="$c &lt; $ccount">
			<xsl:call-template name="draw-cols">
				<xsl:with-param name="c">
					<xsl:value-of select="$c  + 1"/>
				</xsl:with-param>
				<xsl:with-param name="ccount">
					<xsl:value-of select="$ccount"/>
				</xsl:with-param>
			</xsl:call-template>
		</xsl:if>
	</xsl:template>
	
	<xsl:template name="draw-checkboxes">
		<xsl:param name="rcount"/>
		<xsl:param name="r"/>
		
		<!-- Blijf kolommen toevoegen zolang $c kleiner is dan de meegegeven parameter $ccount bij aanroep template -->
		<xsl:if test="$r &lt; number($rcount)">
			<xsl:element name="CheckBox"/>
		</xsl:if>
		<xsl:if test="$r &lt; $rcount">
			<xsl:call-template name="draw-cols">
				<xsl:with-param name="r">
					<xsl:value-of select="$r  + 1"/>
				</xsl:with-param>
				<xsl:with-param name="rcount">
					<xsl:value-of select="$rcount"/>
				</xsl:with-param>
			</xsl:call-template>
		</xsl:if>
	</xsl:template>
	
	<!-- Template om een tekstblok te tekenen -->
	<xsl:template name="get-textblock">
		<xsl:param name="gridrow"/>
		<xsl:param name="gridcol"/>
		<xsl:param name="text"/>
		<xsl:param name="foreground"/>
		<xsl:param name="fontsize"/>
		<xsl:param name="halign"/>
		<xsl:param name="valign"/>
		<xsl:param name="visibility"/>
		<xsl:param name="cellname"/>
		<xsl:param name="cellcount"/>
		<xsl:param name="width"/>
		
		<xsl:element name="Border">
			<xsl:attribute name="Grid.Row">
				<xsl:value-of select="$gridrow"/>
			</xsl:attribute>
			<xsl:attribute name="Grid.Column">
				<xsl:value-of select="$gridcol"/>
			</xsl:attribute>
			<xsl:if test="$width">
				<xsl:attribute name="Width">
					<xsl:value-of select="$width"/>
				</xsl:attribute>
			</xsl:if>
		
			<xsl:element name="TextBlock">
				<xsl:if test="$cellcount">
					<xsl:attribute name="x:Name">
						<xsl:value-of select="concat($cellname,$cellcount)"/>
					</xsl:attribute>
				</xsl:if>
				<xsl:attribute name="Foreground">
					<xsl:value-of select="$foreground"/>
				</xsl:attribute>
				<xsl:attribute name="Text">
					<xsl:value-of select="$text"/>
				</xsl:attribute>
				<xsl:attribute name="HorizontalAlignment">
					<xsl:value-of select="$halign"/>
				</xsl:attribute>
				<xsl:attribute name="VerticalAlignment">
					<xsl:value-of select="$valign"/>
				</xsl:attribute>
				<xsl:if test="$fontsize">
					<xsl:attribute name="FontSize">
						<xsl:value-of select="$fontsize"/>
					</xsl:attribute>
				</xsl:if>
			</xsl:element>
		</xsl:element>
	</xsl:template>
	
	<xsl:template name="print-values">
		<xsl:param name="number" select="1"/>
		<xsl:param name="gridrow">3</xsl:param>
		<xsl:param name="count">0</xsl:param>
		
		<xsl:element name="Border">
			<xsl:attribute name="Grid.Row" select="$gridrow"/>
			<xsl:attribute name="Grid.Column" select="0"/>
			
			<xsl:element name="TextBlock">
				<xsl:attribute name="x:Name" select="concat('number',$number)"/>
				<xsl:attribute name="Text" select="$number"/>
				<xsl:attribute name="Foreground">Ivory</xsl:attribute>
				<xsl:attribute name="HorizontalAlignment">Center</xsl:attribute>
				<xsl:attribute name="VerticalAlignment">Center</xsl:attribute>
			</xsl:element>
		</xsl:element>

		<xsl:for-each select="//value[position()=$number]/@date">
			<xsl:element name="Border">
				<xsl:attribute name="Grid.Row" select="$gridrow"/>
				<xsl:attribute name="Grid.Column" select="1"/>
					
				<xsl:element name="TextBlock">
					<xsl:attribute name="x:Name" select="concat('date',$number)"/>
					<xsl:attribute name="Text" select="."/>
					<xsl:attribute name="Foreground">Ivory</xsl:attribute>
					<xsl:attribute name="HorizontalAlignment">Center</xsl:attribute>
					<xsl:attribute name="VerticalAlignment">Center</xsl:attribute>
				</xsl:element>

			</xsl:element>
		</xsl:for-each>

		<xsl:for-each select="//value[position()=$number]/@valid">
			<xsl:element name="Border">
				<xsl:attribute name="Grid.Row" select="$gridrow"/>
				<xsl:attribute name="Grid.Column" select="2"/>
				
				<xsl:element name="TextBlock">
					<xsl:choose>
						<xsl:when test=". ='no' ">
							<xsl:attribute name="x:Name" select="concat('notValid',$number)"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:attribute name="x:Name" select="concat('valid',$number)"/>
						</xsl:otherwise>
					</xsl:choose>
					
					<xsl:attribute name="Text" select="."/>
					<xsl:attribute name="Foreground">Ivory</xsl:attribute>
					<xsl:attribute name="HorizontalAlignment">Center</xsl:attribute>
					<xsl:attribute name="VerticalAlignment">Center</xsl:attribute>
				</xsl:element>
			</xsl:element>
		</xsl:for-each>

		<xsl:for-each select="//value[position()=$number]/systolic">
			<xsl:element name="Border">
				<xsl:attribute name="Grid.Row" select="$gridrow"/>
				<xsl:attribute name="Grid.Column" select="3"/>
				
				<xsl:element name="TextBlock">
					<xsl:choose>
						<xsl:when test=". > //systolic-limit">
							<xsl:attribute name="x:Name" select="concat('gtSystolicLimit',$number)"/>
						</xsl:when>
						
						<xsl:otherwise>
							<xsl:attribute name="x:Name" select="concat('systolic',$number)"/>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:if test=". &lt; round( sum(//value[@valid='yes']/systolic) div count(//value[@valid='yes']/systolic) )">
							<xsl:attribute name="Tag" select="concat('ltAvgValidSystolic',$number)"/>
						</xsl:if>
					<xsl:attribute name="Text" select="."/>
					<xsl:attribute name="Foreground">Ivory</xsl:attribute>
					<xsl:attribute name="HorizontalAlignment">Center</xsl:attribute>
					<xsl:attribute name="VerticalAlignment">Center</xsl:attribute>
				</xsl:element>
			</xsl:element>
		</xsl:for-each>
		
		<xsl:for-each select="//value[position()=$number]/diastolic">
			<xsl:element name="Border">
				<xsl:attribute name="Grid.Row" select="$gridrow"/>
				<xsl:attribute name="Grid.Column" select="4"/>
				
				<xsl:element name="TextBlock">
					<xsl:choose>
						<xsl:when test=". &lt; number(//diastolic-limit)">
							<xsl:attribute name="x:Name" select="concat('ltDiastolicLimit',$number)"/>
						</xsl:when>
						<xsl:when test=". &gt; sum(//value[@valid='yes']/diastolic) div count(//value[@valid='yes']/diastolic)">
							<xsl:attribute name="Tag" select="concat('gtAvgValidDiastolic',$number)"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:attribute name="x:Name" select="concat('diastolic',$number)"/>
						</xsl:otherwise>
					</xsl:choose>
	
					<xsl:attribute name="Text" select="."/>
					<xsl:attribute name="Foreground">Ivory</xsl:attribute>
					<xsl:attribute name="HorizontalAlignment">Center</xsl:attribute>
					<xsl:attribute name="VerticalAlignment">Center</xsl:attribute>
				</xsl:element>
			</xsl:element>
		</xsl:for-each>
		
		<xsl:if test="$number &lt; 20">
			<xsl:call-template name="print-values">
				<xsl:with-param name="gridrow" select="$gridrow + 1"/>
				<xsl:with-param name="number" select="$number + 1"/>
				<xsl:with-param name="count" select="$count +1"/>
			</xsl:call-template>
		</xsl:if>
	</xsl:template>
	
</xsl:stylesheet>
