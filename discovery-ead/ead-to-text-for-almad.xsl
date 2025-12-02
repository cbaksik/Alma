<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet 
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:ead="urn:isbn:1-931666-22-9"
    exclude-result-prefixes="ead"
    version="1.0">

    <xsl:output method="text" encoding="UTF-8"/>

    <!-- Start processing at the root 'ead:archdesc' -->
    <xsl:template match="/">
        <xsl:apply-templates select="ead:ead/ead:archdesc"/>
    </xsl:template>

    <!-- Main archdesc -->
    <xsl:template match="ead:archdesc">
        <xsl:apply-templates select="ead:did/ead:abstract"/>
        <xsl:apply-templates select="ead:relatedmaterial/ead:p"/>
        <xsl:apply-templates select="ead:bioghist"/>   <!-- select list -->
        <xsl:apply-templates select="ead:bibliography/ead:bibref"/>
        <xsl:apply-templates select="ead:scopecontent/ead:p"/>
        <xsl:apply-templates select="ead:odd/ead:list/ead:item"/>  <!-- select list -->
        <xsl:apply-templates select="ead:dsc/ead:c"/>
    </xsl:template>

    <!-- Bioghist and its sub-structures -->
    <xsl:template match="ead:bioghist">
        <xsl:apply-templates select="
	   ead:p | 
	   ead:persname | 
	   ead:title | 
	   ead:list | 
	   ead:note | 
	   ead:chronlist"/>
    </xsl:template>

    <xsl:template match="ead:chronlist">
        <xsl:apply-templates select="ead:head"/>
        <xsl:apply-templates select="ead:chronitem"/>
    </xsl:template>

    <xsl:template match="ead:chronitem">
        <xsl:apply-templates select="
	   ead:date | 
	   ead:event | 
	   ead:eventgrp/ead:event"/>
    </xsl:template>

    <xsl:template match="ead:chronitem">
        <xsl:apply-templates select="
	   ead:date | 
	   ead:event | 
	   ead:eventgrp/ead:event"/>
    </xsl:template>

    <xsl:template match="ead:item">
        <xsl:apply-templates select="
	   ead:corpname | 
	   ead:genreform | 
	   ead:subject | 
	   ead:persname"/>
    </xsl:template>

<!-- these templates are for elements that don't need commas for snippet readability -->
    <xsl:template match="
    ead:abstract|
    ead:bibref|
    ead:corpname|
    ead:date|
    ead:event|
    ead:genreform |
    ead:head|
    ead:list|
    ead:note|
    ead:persname|
    ead:p|
    ead:relatedmaterial/ead:p|
    ead:scopecontent/ead:p|
    ead:subject|
    ead:title
    ">
<xsl:value-of select="normalize-space(.)"/>
<xsl:text>&#10;</xsl:text>
    </xsl:template>
<!-- these templates are for elements that DO need commas for snippet readability -->
    <xsl:template match="
    ead:item|
    ead:unittitle|
    ead:unitdate 
    ">
<xsl:value-of select="normalize-space(.)"/>
<xsl:text>,&#10;</xsl:text>
    </xsl:template>


    <!-- Recursive component handling (ALL levels) -->
    <xsl:template match="ead:c">
        <xsl:apply-templates select="ead:bioghist"/> <!-- select list -->
        <xsl:apply-templates select="ead:did/ead:unittitle"/>
        <xsl:apply-templates select="ead:did/ead:unitdate"/>
        <xsl:apply-templates select="ead:scopecontent/ead:p"/>
        <xsl:apply-templates select="ead:bibliography/ead:bibref"/>
        <xsl:apply-templates select="ead:relatedmaterial/ead:p"/>
        <xsl:apply-templates select="ead:odd/ead:p"/>
        <xsl:apply-templates select="ead:odd/ead:list/ead:item"/>
        <!-- Process child components recursively -->
        <xsl:apply-templates select="ead:c"/>
    </xsl:template>


</xsl:stylesheet>