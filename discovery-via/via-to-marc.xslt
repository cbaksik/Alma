<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:xlink="http://www.w3.org/TR/xlink"
	exclude-result-prefixes="xlink">
	
	<xsl:output method="xml" indent="yes"/>
	
	<xsl:template match="/">
		
		<ListRecords xmlns:marc="http://www.loc.gov/MARC21/slim" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:schemaLocation="http://www.loc.gov/MARC21/slim http://www.loc.gov/standards/marcxml/schema/MARC21slim.xsd">	
			
			<xsl:for-each select="viaRecord">
				
				<record>
					
					<header>
						<identifier><xsl:value-of select="recordId"/></identifier>
					</header>
					
					<metadata>
						
						<record>
							
							<leader>     nkm a22002295u 4500</leader>
							
							<controlfield tag="001">
								<xsl:value-of select="recordId"/>
							</controlfield>
							
							<controlfield tag="008">
								<xsl:text>      m</xsl:text>
								<xsl:text>        </xsl:text>
								<xsl:text>rb            000 i zxx d</xsl:text>
							</controlfield>
							
							<!-- <datafield tag="035" ind1=" " ind2=" ">
								<subfield code="a">
									<xsl:text>(JSTOR)</xsl:text>
									<xsl:value-of select="recordId"/>
								</subfield>
							</datafield> -->
							
							<xsl:for-each select="work/itemIdentifier">
								<datafield tag="097" ind1=" " ind2=" ">
									<subfield code="a">
										<xsl:value-of select="type"/>
										<xsl:text> </xsl:text>
										<xsl:value-of select="number"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/classification">
								<datafield tag="098" ind1=" " ind2=" ">
									<subfield code="a">
										<xsl:value-of select="type"/>
										<xsl:text> </xsl:text>
										<xsl:value-of select="number"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/creator">
								<datafield tag="100" ind1=" " ind2=" ">
									<subfield code="a">
										<xsl:value-of select="nameElement"/>
									</subfield>
									<subfield code="d">
										<xsl:value-of select="dates"/>
									</subfield>
									<subfield code="e">
										<xsl:value-of select="role"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<datafield tag="245" ind1="1" ind2="0">
								<subfield code="a">
									<xsl:value-of select="work/title[1]/textElement"/>
								</subfield>
							</datafield>

							<xsl:for-each select="work/creatorDisplay">
								<datafield tag="245" ind1="1" ind2="0">
									<subfield code="c">
										<xsl:value-of select="."/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/title[position() &gt; 1]">
								<datafield tag="246" ind1="1" ind2="1">
									<subfield code="i">
										<xsl:value-of select="type"/>
									</subfield>								
									<subfield code="a">
										<xsl:value-of select="textElement"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/state">
								<datafield tag="250" ind1=" " ind2=" ">
									<subfield code="a">
										<xsl:value-of select="."/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/freeDate">
								<datafield tag="264" ind1=" " ind2="1">
									<subfield code="c">
										<xsl:value-of select="."/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<!-- make sure structured date is second so that's what Primo will use to set creationDate for control/search in addition to pubinfo -->
							<xsl:for-each select="work/structuredDate">
								<datafield tag="264" ind1=" " ind2="1">
									<subfield code="c">
										<xsl:value-of select="beginDate"/>
										<xsl:text>-</xsl:text>
										<xsl:value-of select="endDate"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/production/placeOfProduction">
								<datafield tag="264" ind1=" " ind2="0">
									<subfield code="a">
										<xsl:value-of select="place"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/workType">
								<datafield tag="655" ind1=" " ind2="7">
									<subfield code="a">
										<xsl:value-of select="."/>
									</subfield>
									<subfield code="2">
										<xsl:text>via</xsl:text>
									</subfield>								
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/description">
								<datafield tag="300" ind1=" " ind2=" ">
									<subfield code="a">
										<xsl:value-of select="."/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/dimensions">
								<datafield tag="300" ind1=" " ind2=" ">
									<subfield code="a">
										<xsl:value-of select="."/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/notes">
								<datafield tag="500" ind1=" " ind2=" ">
									<subfield code="a">
										<xsl:value-of select="."/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/standardizedRights">
								<datafield tag="540" ind1=" " ind2=" ">
									<subfield code="a">
										<xsl:value-of select="."/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/copyright">
								<datafield tag="542" ind1=" " ind2=" ">
									<subfield code="a">
										<xsl:value-of select="."/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/style">
								<datafield tag="592" ind1="9" ind2="9">
									<subfield code="a">
										<xsl:value-of select="term"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/culture">
								<datafield tag="593" ind1="9" ind2="9">
									<subfield code="a">
										<xsl:value-of select="term"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/relatedWork">
								<datafield tag="594" ind1="9" ind2="9">
									<subfield code="a">
										<xsl:value-of select="textElement"/>
									</subfield>
									<subfield code="e">
										<xsl:value-of select="relationship"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/relatedInformation">
								<datafield tag="595" ind1="9" ind2="9">
									<subfield code="u">
										<xsl:value-of select="@href"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/repository">
								<datafield tag="596" ind1="9" ind2="9">
									<subfield code="a">
										<xsl:value-of select="repositoryName"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/hasLargerContext">
								<datafield tag="597" ind1="8" ind2="8">
									<subfield code="a">
										<xsl:value-of select="contextTitle"/>
									</subfield>
									<subfield code="b">
										<xsl:value-of select="contextID"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/largerContextFor/part">
								<datafield tag="597" ind1="9" ind2="9">
									<subfield code="a">
										<xsl:value-of select="partTitle"/>
									</subfield>
									<subfield code="b">
										<xsl:value-of select="partId"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/subjectName">
								<datafield tag="600" ind1=" " ind2=" ">
									<subfield code="a">
										<xsl:value-of select="nameElement"/>
									</subfield>
									<subfield code="d">
										<xsl:value-of select="dates"/>
									</subfield>
									<subfield code="e">
										<xsl:value-of select="role"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/topic">
								<datafield tag="650" ind1=" " ind2="7">
									<subfield code="a">
										<xsl:value-of select="term"/>
									</subfield>
									<subfield code="2">
										<xsl:text>via</xsl:text>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/subjectPlace">
								<datafield tag="651" ind1=" " ind2="7">
									<subfield code="a">
										<xsl:value-of select="place"/>
									</subfield>
									<subfield code="2">
										<xsl:text>via</xsl:text>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/associatedName">
								<datafield tag="720" ind1=" " ind2=" ">
									<subfield code="a">
										<xsl:value-of select="nameElement"/>
									</subfield>
									<subfield code="d">
										<xsl:value-of select="dates"/>
									</subfield>
									<subfield code="e">
										<xsl:value-of select="role"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/placeName">
								<datafield tag="751" ind1=" " ind2=" ">
									<subfield code="a">
										<xsl:value-of select="place"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/location">
								<datafield tag="751" ind1=" " ind2=" ">
									<subfield code="a">
										<xsl:value-of select="place"/>
									</subfield>								
									<subfield code="e">
										<xsl:value-of select="type"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/image">
								<datafield tag="956" ind1="9" ind2="9">
									<subfield code="u">
										<xsl:value-of select="@xlink:href"/>
									</subfield>								
									<subfield code="v">
										<xsl:value-of select="thumbnail/@xlink:href"/>
									</subfield>
									<subfield code="9">
										<xsl:value-of select="@restrictedImage"/>
									</subfield>									
								</datafield>
							</xsl:for-each>							

			<!-- BEGIN FLATTENED SECTION  -->
							<xsl:for-each select="work">
								<datafield tag="599" ind1="9" ind2="9">
								</datafield>
							</xsl:for-each>
			<!-- END FLATTENED SECTION  -->

			<!-- BEGIN COMPONENT SECTION  -->
							<xsl:for-each select="work/component">
								<datafield tag="974" ind1=" " ind2=" ">
									<subfield code="w">
										<xsl:value-of select="@componentID"/>
									</subfield>
									<subfield code="x">
										<xsl:value-of select="@altComponentID"/>
									</subfield>
									<subfield code="h">
										<xsl:value-of select="image/@restrictedImage"/>
									</subfield>
									<subfield code="u">
										<xsl:value-of select="image/@xlink:href"/>
									</subfield>
									<subfield code="t">
										<xsl:value-of select="hvd_title/textElement"/>
									</subfield>
									<subfield code="f">
										<xsl:value-of select="hvd_workType"/>
									</subfield>									
									<xsl:for-each select="hvd_creator">
										<subfield code="a">
											<xsl:value-of select="concat(nameElement, ', ', dates, ' [', role, ']')"/>
										</subfield>
									</xsl:for-each>									
									<subfield code="d">
										<xsl:value-of select="hvd_freeDate"/>
									</subfield>									
									<xsl:for-each select="hvd_associatedName">
										<subfield code="b">
											<xsl:value-of select="nameElement"/>
										</subfield>
									</xsl:for-each>									
									<xsl:for-each select="hvd_topic">
										<subfield code="s">
											<xsl:value-of select="term"/>
										</subfield>
									</xsl:for-each>									
									<subfield code="m">
										<xsl:value-of select="hvd_materials"/>
									</subfield>									
									<xsl:if test="hvd_notes">
										<subfield code="n">
											<xsl:value-of select="hvd_notes"/>
										</subfield>
									</xsl:if>									
									<subfield code="c">
										<xsl:value-of select="hvd_copyright"/>
									</subfield>									
									<subfield code="r">
										<xsl:value-of select="concat(hvd_repository/repositoryName, ' ', hvd_repository/number)"/>
									</subfield>
									<subfield code="y">
										<xsl:value-of select="concat(hvd_classification/type, ' ', hvd_classification/number)"/>
									</subfield>
									<subfield code="z">
										<xsl:value-of select="concat(hvd_itemIdentifier/type, ' ', hvd_itemIdentifier/number)"/>
									</subfield>
								</datafield>
							</xsl:for-each>
			<!-- BEGIN COMPONENT SECTION  -->

						</record>
					</metadata>
				</record>				
				
			</xsl:for-each>
		</ListRecords>
		
	</xsl:template>
	
</xsl:stylesheet>