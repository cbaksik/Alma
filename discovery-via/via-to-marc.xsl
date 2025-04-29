<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:xlink="http://www.w3.org/TR/xlink"
	xmlns:ino="http://namespaces.softwareag.com/tamino/response2"
	exclude-result-prefixes="ino">
	
	<xsl:output method="xml" indent="yes"/>
	
	<xsl:template match="/ino:request">
		
		<ListRecords xmlns:marc="http://www.loc.gov/MARC21/slim" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:schemaLocation="http://www.loc.gov/MARC21/slim http://www.loc.gov/standards/marcxml/schema/MARC21slim.xsd">	
			
			<xsl:apply-templates select="ino:object/viaRecord"/>

		</ListRecords>
		
	</xsl:template>

	<xsl:template match="viaRecord">


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
							
							
							<datafield tag="099" ind1=" " ind2="9">
								<subfield code="u">
									<xsl:value-of select="@primaryImageThumbnailURN"/>
								</subfield>
								<subfield code="a">
									<xsl:value-of select="@images"/>
								</subfield>
								<subfield code="b">
									<xsl:value-of select="@numberOfImages"/>
								</subfield>
							</datafield>
							
							<xsl:for-each select="work/itemIdentifier">
								<datafield tag="097" ind1=" " ind2="9">
									<subfield code="a">
										<xsl:value-of select="type"/>
										<xsl:text> </xsl:text>
										<xsl:value-of select="number"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/oliviaId">
								<datafield tag="097" ind1=" " ind2="9">
									<subfield code="a">
										<xsl:value-of select="."/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/workRecordId">
								<datafield tag="097" ind1=" " ind2="9">
									<subfield code="a">
										<xsl:value-of select="."/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/containerId">
								<datafield tag="097" ind1=" " ind2="9">
									<subfield code="a">
										<xsl:value-of select="."/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/classification">
								<datafield tag="098" ind1=" " ind2="9">
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
							
							<xsl:for-each select="work/materials">
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
							
							<xsl:for-each select="work/useRestrictions">
								<datafield tag="506" ind1=" " ind2=" ">
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
								<datafield tag="592" ind1=" " ind2="9">
									<subfield code="a">
										<xsl:value-of select="term"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/culture">
								<datafield tag="593" ind1=" " ind2="9">
									<subfield code="a">
										<xsl:value-of select="term"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/relatedWork">
								<datafield tag="594" ind1=" " ind2="9">
									<subfield code="a">
										<xsl:value-of select="textElement"/>
									</subfield>
									<subfield code="e">
										<xsl:value-of select="relationship"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/relatedInformation">
								<datafield tag="595" ind1=" " ind2="9">
									<subfield code="a">
										<xsl:value-of select="@href"/>
									</subfield>
									<subfield code="u">
										<xsl:value-of select="@href"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/repository">
								<datafield tag="596" ind1=" " ind2="9">
									<subfield code="a">
										<xsl:value-of select="repositoryName"/>
										<xsl:text> </xsl:text>
										<xsl:value-of select="number"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/hasLargerContext">
								<datafield tag="597" ind1=" " ind2="9">
									<subfield code="a">
										<xsl:value-of select="contextTitle"/>
									</subfield>
									<subfield code="b">
										<xsl:value-of select="contextID"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/largerContextFor/part">
								<datafield tag="597" ind1=" " ind2="9">
									<subfield code="c">
										<xsl:value-of select="partTitle"/>
									</subfield>
									<subfield code="d">
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
								<datafield tag="956" ind1=" " ind2="9">
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
							<xsl:if test="work/hvd_componentID">

								<datafield tag="599" ind1=" " ind2="9">
									
									<xsl:for-each select="work/hvd_componentID">
										<subfield code="w">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="work/hvd_associatedName">
										<subfield code="n">
											<xsl:value-of select="nameElement"/>
											<xsl:text>, </xsl:text>
											<xsl:value-of select="dates"/>
											<xsl:text> [</xsl:text>
											<xsl:value-of select="role"/>
											<xsl:text>]</xsl:text>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="work/hvd_classification">
										<subfield code="h">
											<xsl:value-of select="number"/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="work/hvd_copyright">
										<subfield code="c">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="work/hvd_creator">
										<subfield code="a">
											<xsl:value-of select="nameElement"/>
											<xsl:text>, </xsl:text>
											<xsl:value-of select="dates"/>
											<xsl:text> [</xsl:text>
											<xsl:value-of select="role"/>
											<xsl:text>]</xsl:text>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="work/hvd_notes">
										<subfield code="z">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="work/hvd_repository">
										<subfield code="r">
											<xsl:value-of select="repositoryName"/>
											<xsl:text> </xsl:text>
											<xsl:value-of select="number"/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="work/hvd_title">
										<subfield code="t">
											<xsl:value-of select="textElement"/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="work/hvd_topic">
										<subfield code="s">
											<xsl:value-of select="term"/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="work/hvd_workType">
										<subfield code="g">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									
								</datafield>
							</xsl:if>						
							
							<!-- END FLATTENED SECTION  -->
							
							
							<!-- BEGIN COMPONENT SECTION  -->
							
							<xsl:for-each select="work/component">
								<datafield tag="974" ind1=" " ind2="9">
									
									<subfield code="w">
										<xsl:value-of select="@componentID"/>
									</subfield>
									
									<xsl:for-each select="associatedName">
										<subfield code="0">
											<xsl:value-of select="nameElement"/>
											<xsl:text>, </xsl:text>
											<xsl:value-of select="dates"/>
											<xsl:text> [</xsl:text>
											<xsl:value-of select="role"/>
											<xsl:text>]</xsl:text>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="classification">
										<subfield code="i">
											<xsl:value-of select="type"/>
											<xsl:text> </xsl:text>
											<xsl:value-of select="number"/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="copyright">
										<subfield code="1">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									
									
									<xsl:for-each select="creator">
										<subfield code="2">
											<xsl:value-of select="nameElement"/>
											<xsl:text>, </xsl:text>
											<xsl:value-of select="dates"/>
											<xsl:text> [</xsl:text>
											<xsl:value-of select="role"/>
											<xsl:text>]</xsl:text>
										</subfield>
									</xsl:for-each>
									
									
									<xsl:for-each select="culture">
										<subfield code="3">
											<xsl:value-of select="term"/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="freeDate">
										<subfield code="4">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="structuredDate">
										<subfield code="4">
											<xsl:value-of select="beginDate"/>
											<xsl:text>-</xsl:text>
											<xsl:value-of select="endDate"/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="image">
										
										<subfield code="u">
											<xsl:value-of select="@xlink:href"/>
										</subfield>								
										<subfield code="y">
											<xsl:value-of select="thumbnail/@xlink:href"/>
										</subfield>
										<subfield code="x">
											<xsl:value-of select="@restrictedImage"/>
										</subfield>									
										
									</xsl:for-each>							
									
									
									<xsl:for-each select="placeName">
										<subfield code="p">
											<xsl:value-of select="place"/>
										</subfield>
									</xsl:for-each>
									<xsl:for-each select="location">
										<subfield code="p">
											<xsl:value-of select="place"/>
											<xsl:text> [</xsl:text>
											<xsl:value-of select="type"/>
											<xsl:text>]</xsl:text>
										</subfield>	
									</xsl:for-each>
									
									
									<xsl:for-each select="description">
										<subfield code="5">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									<xsl:for-each select="dimensions">
										<subfield code="5">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									<xsl:for-each select="materials">
										<subfield code="5">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									<xsl:for-each select="notes">
										<subfield code="5">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="relatedInformation">
										<subfield code="6">
											<xsl:value-of select="text"/>
											<xsl:text>--</xsl:text>
											<xsl:value-of select="@href"/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="relatedWork">
										<subfield code="7">
											<xsl:value-of select="textElement"/>
											<xsl:text> [</xsl:text>
											<xsl:value-of select="relationship"/>
											<xsl:text>]</xsl:text>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="repository">
										<subfield code="8">
											<xsl:value-of select="repositoryName"/>
											<xsl:text> </xsl:text>
											<xsl:value-of select="number"/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="title">
										<subfield code="9">
											<xsl:value-of select="type"/>
											<xsl:text>: </xsl:text>
											<xsl:value-of select="textElement"/>
										</subfield>			
									</xsl:for-each>
									
									<xsl:for-each select="topic">
										<subfield code="b">
											<xsl:value-of select="term"/>
										</subfield>
									</xsl:for-each>
									
									
									<xsl:for-each select="subjectName">
										<subfield code="b">
											<xsl:value-of select="nameElement"/>
											<xsl:text>, </xsl:text>
											<xsl:value-of select="dates"/>
											<xsl:text> [</xsl:text>
											<xsl:value-of select="role"/>
											<xsl:text>]</xsl:text>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="subjectPlace">
										<subfield code="b">
											<xsl:value-of select="place"/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="useRestrictions">
										<subfield code="j">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="workType">
										<subfield code="f">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>	
									
									
									<xsl:for-each select="hvd_associatedName">
										<subfield code="n">
											<xsl:value-of select="nameElement"/>
											<xsl:text>, </xsl:text>
											<xsl:value-of select="dates"/>
											<xsl:text> [</xsl:text>
											<xsl:value-of select="role"/>
											<xsl:text>]</xsl:text>
										</subfield>
									</xsl:for-each>
									
									
									<xsl:for-each select="hvd_classification">
										<subfield code="h">
											<xsl:value-of select="type"/>
											<xsl:text> </xsl:text>
											<xsl:value-of select="number"/>
										</subfield>
									</xsl:for-each>	
									
									<xsl:for-each select="hvd_copyright">
										<subfield code="c">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									
									
									<xsl:for-each select="hvd_useRestrictions">
										<subfield code="k">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="hvd_creator">
										<subfield code="a">
											<xsl:value-of select="nameElement"/>
											<xsl:text>, </xsl:text>
											<xsl:value-of select="dates"/>
											<xsl:text> [</xsl:text>
											<xsl:value-of select="role"/>
											<xsl:text>]</xsl:text>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="hvd_description">
										<subfield code="z">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									<xsl:for-each select="hvd_dimensions">
										<subfield code="z">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									<xsl:for-each select="hvd_materials">
										<subfield code="z">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									<xsl:for-each select="hvd_notes">
										<subfield code="z">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="hvd_freeDate">
										<subfield code="d">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="hvd_structuredDate">
										<subfield code="d">
											<xsl:value-of select="beginDate"/>
											<xsl:text>-</xsl:text>
											<xsl:value-of select="endDate"/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="hvd_repository">
										<subfield code="r">
											<xsl:value-of select="repositoryName"/>
											<xsl:text> </xsl:text>
											<xsl:value-of select="number"/>
										</subfield>
									</xsl:for-each>
									
									
									<xsl:for-each select="hvd_subjectName">
										<subfield code="s">
											<xsl:value-of select="nameElement"/>
											<xsl:text>, </xsl:text>
											<xsl:value-of select="dates"/>
											<xsl:text> [</xsl:text>
											<xsl:value-of select="role"/>
											<xsl:text>]</xsl:text>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="hvd_subjectPlace">
										<subfield code="s">
											<xsl:value-of select="place"/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="hvd_topic">
										<subfield code="s">
											<xsl:value-of select="term"/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="hvd_title">
										<subfield code="t">
											<xsl:value-of select="textElement"/>
										</subfield>			
									</xsl:for-each>
									
									
									<xsl:for-each select="hvd_workType">
										<subfield code="g">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>	
									
								</datafield>
								
							</xsl:for-each>
							
							<!-- END COMPONENT SECTION  -->
							
						</record>
					</metadata>
				</record>				


	</xsl:template>	

</xsl:stylesheet>