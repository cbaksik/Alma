<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet 
   xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
   xmlns:ead="urn:isbn:1-931666-22-9"
   exclude-result-prefixes="ead"
   version="1.0">

   <!-- Output as plain text -->
   <xsl:output method="text" encoding="UTF-8"/>

   <!-- Root template -->
   <xsl:template match="/">
       <xsl:apply-templates select="//ead:archdesc"/>
   </xsl:template>

   <!-- Top-level finding aid summary -->
   <xsl:template match="ead:archdesc">

   		<xsl:for-each select="ead:did"> 
			<xsl:value-of select="ead:abstract"/><xsl:text> </xsl:text>
		</xsl:for-each> 

		<!-- CHECK THIS -->
		<xsl:value-of select="ead:relatedmaterial/ead:p"/><xsl:text>&#10;</xsl:text>

		<xsl:for-each select="ead:bioghist"> 
			<xsl:for-each select="ead:p">
				<xsl:value-of select="."/><xsl:text> </xsl:text>
			</xsl:for-each>
			<xsl:for-each select="ead:list">
				<xsl:value-of select="."/><xsl:text> </xsl:text>
			</xsl:for-each>
			<xsl:for-each select="ead:chronlist">				
				<xsl:for-each select="ead:head">					
					<xsl:value-of select="."/><xsl:text> </xsl:text>			
				</xsl:for-each>
				<xsl:for-each select="ead:chronitem">		
					<xsl:for-each select="ead:date">
						<xsl:value-of select="."/><xsl:text> </xsl:text>
					</xsl:for-each>
					<xsl:for-each select="ead:event">
						<xsl:value-of select="."/><xsl:text> </xsl:text>
					</xsl:for-each>
					<xsl:for-each select="ead:eventgrp/ead:event">
						<xsl:value-of select="."/><xsl:text> </xsl:text>
					</xsl:for-each>
				</xsl:for-each>
				</xsl:for-each>
			</xsl:for-each>

		<xsl:for-each select="ead:bibliography/ead:bibref">
			<xsl:value-of select="."/><xsl:text> </xsl:text>
		</xsl:for-each>

   		 <!-- <xsl:for-each select="ead:arrangement/ead:list/ead:item">
   			<xsl:value-of select="."/><xsl:text>&#10;</xsl:text>
		 </xsl:for-each> -->

		<xsl:for-each select="ead:scopecontent/ead:p">
			<xsl:value-of select="."/><xsl:text>&#10;</xsl:text>
		</xsl:for-each>

		<xsl:for-each select="ead:odd/ead:list/ead:item/ead:persname">
			<xsl:value-of select="."/><xsl:text>&#10;</xsl:text>
		</xsl:for-each>

		<xsl:for-each select="ead:odd/ead:list/ead:item/ead:corpname">
			<xsl:value-of select="."/><xsl:text>&#10;</xsl:text>
		</xsl:for-each>

		<xsl:for-each select="ead:odd/ead:list/ead:item/ead:subject">
			<xsl:value-of select="."/><xsl:text>&#10;</xsl:text>
		</xsl:for-each>

		<xsl:for-each select="ead:odd/ead:list/ead:item/ead:genreform">
			<xsl:value-of select="."/><xsl:text>&#10;</xsl:text>
		</xsl:for-each>
		
		<!-- first c -->
		<xsl:for-each select="ead:dsc/ead:c">
			<xsl:for-each select="ead:bioghist"> 
				<xsl:for-each select="ead:p">
					<xsl:value-of select="."/><xsl:text> </xsl:text>
				</xsl:for-each>
			</xsl:for-each>
			<xsl:value-of select="ead:did/ead:unittitle"/><xsl:text>&#10;</xsl:text>
			<xsl:value-of select="ead:scopecontent/ead:p"/><xsl:text>&#10;</xsl:text>
			<!-- second c -->
			<xsl:for-each select="ead:c">

				<xsl:value-of select="ead:did/ead:unittitle"/><xsl:text> </xsl:text>

				<xsl:for-each select="ead:bioghist"> 
					<xsl:for-each select="ead:p">
						<xsl:value-of select="."/><xsl:text> </xsl:text>
					</xsl:for-each>
				</xsl:for-each>

				<xsl:value-of select="ead:relatedmaterial/ead:p"/><xsl:text>&#10;</xsl:text>

				<xsl:for-each select="ead:scopecontent/ead:p">
					<xsl:value-of select="."/><xsl:text>&#10;</xsl:text>
				</xsl:for-each>

				<!-- third c -->
				<xsl:for-each select="ead:c">
					

					<xsl:for-each select="ead:bioghist"> 
						<xsl:for-each select="ead:p">
							<xsl:value-of select="."/><xsl:text> </xsl:text>
						</xsl:for-each>
					</xsl:for-each>


				</xsl:for-each>
				<!-- fourth c -->
					<xsl:for-each select="ead:c">

						<xsl:for-each select="ead:bioghist"> 
							<xsl:for-each select="ead:p">
								<xsl:value-of select="."/><xsl:text> </xsl:text>
							</xsl:for-each>
						</xsl:for-each>


					</xsl:for-each>
			</xsl:for-each>
		</xsl:for-each>
		

   </xsl:template>




</xsl:stylesheet>