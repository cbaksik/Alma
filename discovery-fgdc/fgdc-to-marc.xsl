<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet 
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    version="1.0">
	
	<xsl:output method="xml" indent="yes" encoding="UTF-8"/>

	 <xsl:template match="/">
        <xsl:apply-templates select="metadata"/>
      </xsl:template>

	<xsl:template match="metadata">
		<ListRecords>	
			<record>					
				<header>
					<identifier><xsl:value-of select="@layerid"/></identifier>
				</header>					
				<metadata>
					<record>
							
						<leader>     nem a22002295u 4500</leader>
							
						<controlfield tag="001">
							<xsl:value-of select="@layerid"/>
						</controlfield>
							
						<controlfield tag="003">
							<xsl:text>HvdFgdc</xsl:text>
						</controlfield>
							
						<!-- 18-34 not done yet -->
						<controlfield tag="008">
							<xsl:text>      e</xsl:text>
							<xsl:choose>
								<xsl:when test="translate(idinfo/citation/citeinfo/pubdate, '0123456789', '') = '' and string-length(idinfo/citation/citeinfo/pubdate) = 6 ">
										<xsl:value-of select="idinfo/citation/citeinfo/pubdate"/>
								</xsl:when>
								<xsl:otherwise>
									<xsl:text>      </xsl:text>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:text>  </xsl:text>
							<xsl:text>rb            000 i ||| d</xsl:text>
						</controlfield>
							
						<xsl:for-each select="idinfo/citation/citeinfo">
							<datafield tag="245" ind1="1" ind2="0">
								<subfield code="a">
									<xsl:value-of select="title"/>
								</subfield>
							</datafield>
							<xsl:for-each select="origin">
								<datafield tag="720" ind1=" " ind2=" ">
									<subfield code="a">
										<xsl:value-of select="."/>
									</subfield>
								</datafield>
							</xsl:for-each>
							<xsl:for-each select="edition">
								<datafield tag="250" ind1=" " ind2=" ">
									<subfield code="a">
										<xsl:value-of select="."/>
									</subfield>
								</datafield>
							</xsl:for-each>
							<xsl:for-each select="geoform">
								<datafield tag="300" ind1=" " ind2=" ">
									<subfield code="a">
										<xsl:value-of select="."/>
									</subfield>
								</datafield>
							</xsl:for-each>							
						</xsl:for-each>		
						
						<datafield tag="590" ind1=" " ind2="9">
							<subfield code="u">
								<xsl:value-of select="idinfo/citation/citeinfo/onlink"/>
							</subfield>
						</datafield>

						<xsl:for-each select="idinfo/citation/citeinfo/pubinfo">
							<datafield tag="264" ind1="3" ind2="1">
								<subfield code="a">
									<xsl:value-of select="pubplace"/>
								</subfield>
								<subfield code="b">
									<xsl:value-of select="publish"/>
								</subfield>
							</datafield>
						</xsl:for-each>
						
						<datafield tag="264" ind1="3" ind2="1">
							<subfield code="c">
								<xsl:value-of select="idinfo/timeperd/timeinfo/sngdate/caldate"/>
							</subfield>
						</datafield>

						<xsl:for-each select="idinfo/descript/abstract">
							<datafield tag="520" ind1=" " ind2=" ">
								<subfield code="a">
									<xsl:value-of select="."/>
								</subfield>
							</datafield>
						</xsl:for-each>

						<xsl:for-each select="idinfo/descript/purpose">
							<datafield tag="545" ind1=" " ind2=" ">
								<subfield code="a">
									<xsl:value-of select="."/>
								</subfield>
							</datafield>
						</xsl:for-each>

						<xsl:for-each select="idinfo/descript/supplinf">
							<datafield tag="500" ind1=" " ind2=" ">
								<subfield code="a">
									<xsl:value-of select="."/>
								</subfield>
							</datafield>
						</xsl:for-each>
							
						<!-- lat/long bounding decimal-->

						<xsl:for-each select="idinfo/spdom/bounding">
							<datafield tag="034" ind1="0" ind2=" ">
								<subfield code="d">
									<xsl:value-of select="westbc"/>
								</subfield>
								<subfield code="e">
									<xsl:value-of select="eastbc"/>
								</subfield>
								<subfield code="f">
									<xsl:value-of select="northbc"/>
								</subfield>
								<subfield code="g">
									<xsl:value-of select="southbc"/>
								</subfield>
							</datafield>
						</xsl:for-each>

						<xsl:for-each select="idinfo/keywords/theme">
							<xsl:if test="themekt ='LCSH'">
								<xsl:for-each select="themekey">
									<datafield tag="650" ind1=" " ind2="0">
										<subfield code="a">
											<xsl:value-of select="."/>
										</subfield>
									</datafield>
								</xsl:for-each>
							</xsl:if>
						</xsl:for-each>		

						<xsl:for-each select="idinfo/keywords/place">
							<xsl:if test="placekt ='GNS' or placekt ='LCSH'">
								<xsl:for-each select="placekey">
									<datafield tag="651" ind1=" " ind2="0">
										<subfield code="a">
											<xsl:value-of select="."/>
										</subfield>
									</datafield>
								</xsl:for-each>
							</xsl:if>
						</xsl:for-each>	
						
						<xsl:for-each select="idinfo/keywords/temporal">
							<xsl:for-each select="tempkey">
								<datafield tag="653" ind1=" " ind2=" ">
									<subfield code="a">
										<xsl:value-of select="."/>
									</subfield>
								</datafield>
							</xsl:for-each>
						</xsl:for-each>

						<datafield tag="655" ind1=" " ind2="7">
							<subfield code="a">
								<xsl:text>Geospatial data</xsl:text>
							</subfield>
							<subfield code="2">
								<xsl:text>lcgft </xsl:text>
							</subfield>		
						</datafield>

							
						<xsl:for-each select="idinfo/accconst">
							<datafield tag="506" ind1=" " ind2=" ">
								<subfield code="a">
									<xsl:value-of select="."/>
								</subfield>
							</datafield>
						</xsl:for-each>

						<xsl:for-each select="idinfo/useconst">
							<datafield tag="540" ind1=" " ind2=" ">
								<subfield code="a">
									<xsl:value-of select="."/>
								</subfield>
							</datafield>
						</xsl:for-each>	

						<xsl:for-each select="eainfo/detailed/attr/attrdef">
							<datafield tag="552" ind1=" " ind2=" ">
								<subfield code="a">
									<xsl:value-of select="."/>
								</subfield>
							</datafield>
						</xsl:for-each>

	
					</record>
				</metadata>
			</record>				
		</ListRecords>

	</xsl:template>	

</xsl:stylesheet>