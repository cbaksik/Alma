<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:ead="urn:isbn:1-931666-22-9"
    exclude-result-prefixes="ead"
    version="1.0">

    <xsl:output method="text" encoding="UTF-8"/>

    <!-- One key over every piece of text we pull from the components (ead:c at any depth),
         indexed by its normalized string value. Used for Muenchian-style de-duplication:
         a value is only output the first time it appears anywhere in the dsc. -->
    <xsl:key name="dscText" use="normalize-space(.)" match="
        ead:dsc//ead:c/ead:bioghist/ead:p |
        ead:dsc//ead:c/ead:bioghist/ead:persname |
        ead:dsc//ead:c/ead:bioghist/ead:title |
        ead:dsc//ead:c/ead:bioghist/ead:list |
        ead:dsc//ead:c/ead:bioghist/ead:note |
        ead:dsc//ead:c/ead:bioghist/ead:chronlist/ead:head |
        ead:dsc//ead:c/ead:bioghist/ead:chronlist/ead:chronitem/ead:date |
        ead:dsc//ead:c/ead:bioghist/ead:chronlist/ead:chronitem/ead:event |
        ead:dsc//ead:c/ead:bioghist/ead:chronlist/ead:chronitem/ead:eventgrp/ead:event |
        ead:dsc//ead:c/ead:did/ead:unittitle |
        ead:dsc//ead:c/ead:did/ead:unitdate |
        ead:dsc//ead:c/ead:scopecontent/ead:p |
        ead:dsc//ead:c/ead:bibliography/ead:bibref |
        ead:dsc//ead:c/ead:relatedmaterial/ead:p |
        ead:dsc//ead:c/ead:odd/ead:p |
        ead:dsc//ead:c/ead:odd/ead:list/ead:item"/>

    <!-- Start processing at the root 'ead:archdesc' -->
    <xsl:template match="/">
        <xsl:if test="ead:ead/ead:eadheader/ead:eadid">
        	<xsl:apply-templates select="ead:ead/ead:archdesc"/>
    	   </xsl:if>
    </xsl:template>

    <!-- Main archdesc -->
    <xsl:template match="ead:archdesc">
        <xsl:apply-templates select="ead:did/ead:abstract"/>
        <xsl:apply-templates select="ead:relatedmaterial/ead:p"/>
        <xsl:apply-templates select="ead:bioghist"/>   <!-- select list -->
        <xsl:apply-templates select="ead:bibliography/ead:bibref"/>
        <xsl:apply-templates select="ead:scopecontent/ead:p"/>
        <xsl:apply-templates select="ead:odd/ead:list/ead:item"/>  <!-- select list -->
        <xsl:apply-templates select="ead:dsc"/>
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


    <!-- Components (ALL levels), de-duplicated.
         Instead of recursing c by c, walk every matching node in the dsc in document order
         and output it only if it is the first node with that normalized text. -->
    <xsl:template match="ead:dsc">
        <xsl:for-each select="
            .//ead:c/ead:bioghist/ead:p |
            .//ead:c/ead:bioghist/ead:persname |
            .//ead:c/ead:bioghist/ead:title |
            .//ead:c/ead:bioghist/ead:list |
            .//ead:c/ead:bioghist/ead:note |
            .//ead:c/ead:bioghist/ead:chronlist/ead:head |
            .//ead:c/ead:bioghist/ead:chronlist/ead:chronitem/ead:date |
            .//ead:c/ead:bioghist/ead:chronlist/ead:chronitem/ead:event |
            .//ead:c/ead:bioghist/ead:chronlist/ead:chronitem/ead:eventgrp/ead:event |
            .//ead:c/ead:did/ead:unittitle |
            .//ead:c/ead:did/ead:unitdate |
            .//ead:c/ead:scopecontent/ead:p |
            .//ead:c/ead:bibliography/ead:bibref |
            .//ead:c/ead:relatedmaterial/ead:p |
            .//ead:c/ead:odd/ead:p |
            .//ead:c/ead:odd/ead:list/ead:item">
            <xsl:if test="normalize-space(.) != '' and
                          generate-id(.) = generate-id(key('dscText', normalize-space(.))[1])">
                <xsl:apply-templates select="."/>
            </xsl:if>
        </xsl:for-each>
    </xsl:template>


</xsl:stylesheet>
