<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:xlink="http://www.w3.org/TR/xlink"
	xmlns:ino="http://namespaces.softwareag.com/tamino/response2">
	
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
							
							<controlfield tag="003">
								<xsl:text>jstorHvdImg</xsl:text>
							</controlfield>
							
							<controlfield tag="008">
								<xsl:text>      s</xsl:text>
								<xsl:choose>
									<xsl:when test="string-length(work/structuredDate/beginDate) = 4 and translate(work/structuredDate/beginDate, '0123456789', '') = '' and (starts-with(work/structuredDate/beginDate, '1') or starts-with(work/structuredDate/beginDate, '2'))">
											<xsl:value-of select="work/structuredDate/beginDate"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:text>    </xsl:text>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:text>    </xsl:text>
								<xsl:text>rb            000 i ||| d</xsl:text>
							</controlfield>
							
							
							<datafield tag="590" ind1=" " ind2="9">
								<xsl:if test="@images='true'">
									<subfield code="u">
										<xsl:choose>
											<xsl:when test="@primaryImageThumbnailURN">
												<xsl:value-of select="@primaryImageThumbnailURN"/>
											</xsl:when>
											<xsl:when test="work/image">
												<xsl:value-of select="work/image/@xlink:href"/>
											</xsl:when>
											<xsl:otherwise test="work/component">
												<xsl:value-of select="work/component/image/@xlink:href"/>
											</xsl:otherwise>
										</xsl:choose>
									</subfield>
								</xsl:if>
								<subfield code="b">
									<xsl:value-of select="@numberOfImages"/>
								</subfield>
								<subfield code="c">
									<xsl:value-of select="@originalAtHarvard"/>
								</subfield>
							<!-- work/image will onlyy appear for single image records -->
								<xsl:if test="work/image">
									<subfield code="h">
										<xsl:value-of select="work/image/@xlink:href"/>
									</subfield>
									<xsl:if test="work/image/@restrictedImage='true'">
										<subfield code="r">
											<xsl:value-of select="work/image/@restrictedImage"/>
										</subfield>
									</xsl:if>
								</xsl:if>

								<xsl:if test="recordId/@altRecordId">
									<subfield code="w">
										<xsl:value-of select="recordId/@altRecordId"/>
									</subfield>
								</xsl:if>



								<xsl:for-each select="work/itemIdentifier">
									<subfield code="w">
										<xsl:value-of select="type"/>
										<xsl:text> </xsl:text>
										<xsl:value-of select="number"/>
									</subfield>
								</xsl:for-each>
								<xsl:for-each select="work/oliviaId">
									<subfield code="w">
										<xsl:value-of select="."/>
									</subfield>
								</xsl:for-each>
								<xsl:for-each select="work/workRecordId">
									<subfield code="w">
										<xsl:value-of select="."/>
									</subfield>
								</xsl:for-each>
								<xsl:for-each select="work/containerId">
									<subfield code="w">
										<xsl:value-of select="."/>
									</subfield>
								</xsl:for-each>
								<xsl:for-each select="work/classification">
									<subfield code="w">										
										<xsl:value-of select="type"/>
										<xsl:text> </xsl:text>
										<xsl:value-of select="number"/>
									</subfield>
								</xsl:for-each>

								<!-- alt terms for indexing-->
								<xsl:for-each select="work//alternativeTerm|work//component/alternativeTerm">
									<subfield code="v">										
										<xsl:value-of select="."/>
									</subfield>
								</xsl:for-each>
								<xsl:for-each select="work//alternativeName|work//component/alternativeName">
									<subfield code="v">										
										<xsl:value-of select="."/>
									</subfield>
								</xsl:for-each>

								<!-- lat/long at work level-->
								 <xsl:for-each select="work/location/coordinates">
									<subfield code="l">										
										<xsl:if test="latitude">
											<xsl:text>~lat </xsl:text>
											<xsl:if test="latitude/@decimal">
												<xsl:text>decimal="</xsl:text>
												<xsl:value-of select="latitude/@decimal"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="latitude/@degree">
												<xsl:text>degree="</xsl:text>
												<xsl:value-of select="latitude/@degree"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="latitude/@minute">
												<xsl:text>minute="</xsl:text>
												<xsl:value-of select="latitude/@minute"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="latitude/@second">
												<xsl:text>second="</xsl:text>
												<xsl:value-of select="latitude/@second"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="latitude/@direction">
												<xsl:text>direction="</xsl:text>
												<xsl:value-of select="latitude/@direction"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
										</xsl:if>
										<xsl:if test="longitude">
											<xsl:text>~long </xsl:text>
											<xsl:if test="longitude/@decimal">
												<xsl:text>decimal="</xsl:text>
												<xsl:value-of select="longitude/@decimal"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="longitude/@degree">
												<xsl:text>degree="</xsl:text>
												<xsl:value-of select="longitude/@degree"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="longitude/@minute">
												<xsl:text>minute="</xsl:text>
												<xsl:value-of select="longitude/@minute"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="longitude/@second">
												<xsl:text>second="</xsl:text>
												<xsl:value-of select="longitude/@second"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="longitude/@direction">
												<xsl:text>direction="</xsl:text>
												<xsl:value-of select="longitude/@direction"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
										</xsl:if>
									</subfield>
								</xsl:for-each>
								<xsl:for-each select="work/subjectPlace/coordinates">
									<subfield code="n">										
										<xsl:if test="latitude">
											<xsl:text>~lat </xsl:text>
											<xsl:if test="latitude/@decimal">
												<xsl:text>decimal="</xsl:text>
												<xsl:value-of select="latitude/@decimal"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="latitude/@degree">
												<xsl:text>degree="</xsl:text>
												<xsl:value-of select="latitude/@degree"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="latitude/@minute">
												<xsl:text>minute="</xsl:text>
												<xsl:value-of select="latitude/@minute"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="latitude/@second">
												<xsl:text>second="</xsl:text>
												<xsl:value-of select="latitude/@second"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="latitude/@direction">
												<xsl:text>direction="</xsl:text>
												<xsl:value-of select="latitude/@direction"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
										</xsl:if>
										<xsl:if test="longitude">
											<xsl:text>~long </xsl:text>
											<xsl:if test="longitude/@decimal">
												<xsl:text>decimal="</xsl:text>
												<xsl:value-of select="longitude/@decimal"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="longitude/@degree">
												<xsl:text>degree="</xsl:text>
												<xsl:value-of select="longitude/@degree"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="longitude/@minute">
												<xsl:text>minute="</xsl:text>
												<xsl:value-of select="longitude/@minute"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="longitude/@second">
												<xsl:text>second="</xsl:text>
												<xsl:value-of select="longitude/@second"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="longitude/@direction">
												<xsl:text>direction="</xsl:text>
												<xsl:value-of select="longitude/@direction"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
										</xsl:if>
									</subfield>
								</xsl:for-each>
								<xsl:for-each select="work/placeOfProduction/coordinates">
									<subfield code="m">										
										<xsl:if test="latitude">
											<xsl:text>~lat </xsl:text>
											<xsl:if test="latitude/@decimal">
												<xsl:text>decimal="</xsl:text>
												<xsl:value-of select="latitude/@decimal"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="latitude/@degree">
												<xsl:text>degree="</xsl:text>
												<xsl:value-of select="latitude/@degree"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="latitude/@minute">
												<xsl:text>minute="</xsl:text>
												<xsl:value-of select="latitude/@minute"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="latitude/@second">
												<xsl:text>second="</xsl:text>
												<xsl:value-of select="latitude/@second"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="latitude/@direction">
												<xsl:text>direction="</xsl:text>
												<xsl:value-of select="latitude/@direction"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
										</xsl:if>
										<xsl:if test="longitude">
											<xsl:text>~long </xsl:text>
											<xsl:if test="longitude/@decimal">
												<xsl:text>decimal="</xsl:text>
												<xsl:value-of select="longitude/@decimal"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="longitude/@degree">
												<xsl:text>degree="</xsl:text>
												<xsl:value-of select="longitude/@degree"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="longitude/@minute">
												<xsl:text>minute="</xsl:text>
												<xsl:value-of select="longitude/@minute"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="longitude/@second">
												<xsl:text>second="</xsl:text>
												<xsl:value-of select="longitude/@second"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="longitude/@direction">
												<xsl:text>direction="</xsl:text>
												<xsl:value-of select="longitude/@direction"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
										</xsl:if>
									</subfield>
								</xsl:for-each>
								


							</datafield>							

							
                                    <xsl:variable name="allRepositories" select="work/repository|work/hvd_repository|work/component/repository|work/component/hvd_repository" />

								
								<!-- for troubleshooting only -->
							 	<!-- <xsl:for-each select="$allRepositories/repositoryName">
									<datafield tag="590" ind1=" " ind2="9">
											<subfield code="|">
												<xsl:value-of select="."/>
											</subfield>
									</datafield>									
								</xsl:for-each> -->


									<xsl:if test="$allRepositories/repositoryName[contains(., 'Arnold Arboretum')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-ajp</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Artemas Ward')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-artw</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Baker Library') or contains(., 'Harvard Business')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-bak</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Berenson Art')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-bera</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Fototeca') and contains(., 'Berenson')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-berf</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Biblioteca Berenson') and not(contains(., 'Fototeca'))]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-berb</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Cabot Science')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-cab</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Hellenic Studies')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-hel</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Dumbarton Oaks')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-ddo</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Ernst Mayr')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-mcz</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Fung')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-fun</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Gray Herbarium')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-gra</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Gutman')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-gut</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Harvard Art Museum') or contains(., 'Harvard University Art')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-artm</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Harvard Divinity') or contains(., 'Andover-Harvard')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-div</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Harvard Film')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-hfa</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Harvard Fine Arts') and contains(., 'Digital')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-fald</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Harvard Fine Arts') and contains(., 'Special')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-fals</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Harvard Forest')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-for</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Harvard Kennedy')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-ksg</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Harvard Law')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-lawl</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Harvard Portrait')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-lawp</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Harvard Theatre')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-hout</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Harvard University Archive')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-hua</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Harvard-Yenching')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-hyl</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'History of Medicine') and contains(., 'Warren')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-medw</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'History of Medicine')and not(contains(., 'Warren'))]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-medh</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Houghton Library')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-houl</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Loeb') and contains(., 'Design')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-des</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Loeb Music')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-mus</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Milman Parry')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-ora</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Observatory')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-hco</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Peabody Museum')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-pea</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Radcliffe College')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-schr</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Schlesinger Library')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-schl</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Theodore Roosevelt')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-hour</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Tozzer Library')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-toz</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Slavic') and contains(., 'Widener')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-wids</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Middle East') and contains(., 'Widener')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-widm</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Judaica') and contains(., 'Widener')]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-widj</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>
									<xsl:if test="$allRepositories/repositoryName[contains(., 'Widener') and not(contains(., 'Slavic')) and not(contains(., 'Middle East')) and not(contains(., 'Judaica'))]">
										<datafield tag="590" ind1=" " ind2="9">
											<subfield code="f">
												<xsl:text>facet-img-widl</xsl:text>
											</subfield>
										</datafield>
									</xsl:if>

							<xsl:for-each select="work/creator">
								<datafield tag="100" ind1=" " ind2=" ">
									<subfield code="a">
										<xsl:value-of select="nameElement"/>
									</subfield>
									<xsl:if test="dates">
										<subfield code="d">
											<xsl:value-of select="dates"/>
										</subfield>
									</xsl:if>	
									<xsl:if test="role">
										<subfield code="e">
											<xsl:value-of select="role"/>
										</subfield>
									</xsl:if>	
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
								<datafield tag="246" ind1="2" ind2=" ">
									<xsl:choose>
										<xsl:when test="type='Alternate Title'"></xsl:when>
										<xsl:when test="type='alternate'"></xsl:when>
										<xsl:otherwise>
											<subfield code="i">
												<xsl:value-of select="type"/>
											</subfield>	
										</xsl:otherwise>
									</xsl:choose>
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

							<xsl:choose>
								<xsl:when test="work/freeDate">
									<datafield tag="264" ind1=" " ind2="0">
										<subfield code="c">
											<xsl:value-of select="work/freeDate"/>
										</subfield>
									</datafield>
								</xsl:when>
								<xsl:when test="work/structuredDate">
									<datafield tag="264" ind1=" " ind2="0">
									<subfield code="c">
										<xsl:value-of select="work/structuredDate/beginDate"/>
										<xsl:text>-</xsl:text>
										<xsl:value-of select="work/structuredDate/endDate"/>
									</subfield>
								</datafield>
								</xsl:when>
								<xsl:otherwise></xsl:otherwise>
							</xsl:choose>
							
							<xsl:for-each select="work/production/placeOfProduction|work/placeOfProduction">
								<datafield tag="264" ind1=" " ind2="0">
									<subfield code="a">
										<xsl:value-of select="place"/>
									</subfield>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/description">
								<datafield tag="520" ind1=" " ind2=" ">
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
								<datafield tag="340" ind1=" " ind2=" ">
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
									<subfield code="n">
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
									<xsl:if test="relationship">
										<subfield code="e">
											<xsl:value-of select="relationship"/>
											<xsl:text>: </xsl:text>
										</subfield>
									</xsl:if>
									<subfield code="a">
										<xsl:value-of select="textElement"/>
									</subfield>
										
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/relatedInformation">
								<datafield tag="595" ind1=" " ind2="9">
									<subfield code="a">
										<xsl:value-of select="text"/>
									</subfield>
									<xsl:if test="@href">
										<subfield code="u">
											<xsl:value-of select="@href"/>
										</subfield>
									</xsl:if>
									<xsl:if test="link">
										<subfield code="u">
											<xsl:value-of select="link"/>
										</subfield>
									</xsl:if>									
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/repository">
								<datafield tag="596" ind1=" " ind2="9">
									<subfield code="a">
										<xsl:value-of select="repositoryName"/>
									</subfield>
									<xsl:if test="number">
										<subfield code="b">
											<xsl:value-of select="number"/>
										</subfield>
									</xsl:if>
								</datafield>
							</xsl:for-each>
							
							<xsl:for-each select="work/hasLargerContext">
								<datafield tag="597" ind1=" " ind2="9">
									<subfield code="a">
										<xsl:value-of select="contextTitle"/>
									</subfield>
									<subfield code="b">
										<xsl:value-of select="contextId"/>
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
									<xsl:if test="dates">
										<subfield code="d">
											<xsl:value-of select="dates"/>
										</subfield>
									</xsl:if>		
									<xsl:if test="role">
										<subfield code="e">
											<xsl:value-of select="role"/>
										</subfield>
									</xsl:if>	
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
									<xsl:if test="dates">
										<subfield code="d">
											<xsl:value-of select="dates"/>
										</subfield>
									</xsl:if>	
									<xsl:if test="role">
										<subfield code="e">
											<xsl:value-of select="role"/>
										</subfield>
									</xsl:if>	
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
									<xsl:if test="type">
										<subfield code="e">
											<xsl:value-of select="type"/>
										</subfield>
									</xsl:if>
								</datafield>
							</xsl:for-each>							
							
							<!-- BEGIN FLATTENED SECTION  -->
							<xsl:if test="work/hvd_componentID">

								<datafield tag="598" ind1=" " ind2="9">
									
									<xsl:for-each select="work/hvd_componentID">
										<subfield code="w">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									
									<xsl:if test="work/hvd_associatedName">
										<subfield code="n">
											<xsl:for-each select="work/hvd_associatedName">
												<xsl:if test="position() > 1">
													<xsl:text> ; </xsl:text>
												</xsl:if>
		  										<xsl:value-of select="nameElement"/>
												<xsl:if test="dates">
													<xsl:text>, </xsl:text>
													<xsl:value-of select="dates"/>
												</xsl:if>
												<xsl:if test="role">
													<xsl:text> [</xsl:text>
													<xsl:value-of select="role"/>
													<xsl:text>]</xsl:text>
												</xsl:if>											
											</xsl:for-each>
										</subfield>
									</xsl:if>
									
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
									
									<xsl:if test="work/hvd_creator">
										<subfield code="a">
											<xsl:for-each select="work/hvd_creator">
												<xsl:if test="position() > 1">
													<xsl:text> ; </xsl:text>
												</xsl:if>
												<xsl:value-of select="nameElement"/>
												<xsl:if test="dates">
													<xsl:text>, </xsl:text>
													<xsl:value-of select="dates"/>
												</xsl:if>
												<xsl:if test="role">
													<xsl:text> [</xsl:text>
													<xsl:value-of select="role"/>
													<xsl:text>]</xsl:text>
												</xsl:if>
											</xsl:for-each>
										</subfield>
									</xsl:if>

									<xsl:if test="work/hvd_subjectName">
										<subfield code="s">
											<xsl:for-each select="work/hvd_subjectName">
												<xsl:if test="position() > 1">
													<xsl:text> ; </xsl:text>
												</xsl:if>
												<xsl:value-of select="nameElement"/>
												<xsl:if test="dates">
													<xsl:text>, </xsl:text>
													<xsl:value-of select="dates"/>
												</xsl:if>
												<xsl:if test="role">
													<xsl:text> [</xsl:text>
													<xsl:value-of select="role"/>
													<xsl:text>]</xsl:text>
												</xsl:if>
											</xsl:for-each>
										</subfield>
									</xsl:if>
									
									<xsl:for-each select="work/hvd_notes">
										<subfield code="z">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="work/hvd_repository">
										<subfield code="r">
											<xsl:value-of select="repositoryName"/>
											<xsl:if test="number">
												<xsl:text> </xsl:text>
												<xsl:value-of select="number"/>
											</xsl:if>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="work/hvd_title">
										<subfield code="t">
											<xsl:value-of select="textElement"/>
										</subfield>
									</xsl:for-each>
									
									<xsl:if test="work/hvd_topic">
										<subfield code="s">
											<xsl:for-each select="work/hvd_topic">
												<xsl:if test="position() > 1">
													<xsl:text> ; </xsl:text>
												</xsl:if>
												<xsl:value-of select="term"/>
											</xsl:for-each>
										</subfield>
									</xsl:if>
									
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
								<datafield tag="599" ind1=" " ind2="9">
									
									<subfield code="w">
										<xsl:value-of select="@componentID"/>
									</subfield>
									
									<xsl:for-each select="associatedName">
										<subfield code="0">
											<xsl:value-of select="nameElement"/>
											<xsl:if test="dates">
												<xsl:text>, </xsl:text>
												<xsl:value-of select="dates"/>
											</xsl:if>
											<xsl:if test="role">
												<xsl:text> [</xsl:text>
												<xsl:value-of select="role"/>
												<xsl:text>]</xsl:text>
											</xsl:if>
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
											<xsl:if test="dates">
												<xsl:text>, </xsl:text>
												<xsl:value-of select="dates"/>
											</xsl:if>
											<xsl:if test="role">
												<xsl:text> [</xsl:text>
												<xsl:value-of select="role"/>
												<xsl:text>]</xsl:text>
											</xsl:if>
										</subfield>
									</xsl:for-each>									
									
									<xsl:for-each select="culture">
										<subfield code="3">
											<xsl:value-of select="term"/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="style">
										<subfield code="m">
											<xsl:value-of select="term"/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="freeDate">
										<subfield code="4">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									
									<!-- <xsl:for-each select="structuredDate">
										<subfield code="4">
											<xsl:value-of select="beginDate"/>
											<xsl:text>-</xsl:text>
											<xsl:value-of select="endDate"/>
										</subfield>
									</xsl:for-each> -->
									
									<xsl:for-each select="image">
										
										<subfield code="u">
											<xsl:value-of select="@xlink:href"/>
										</subfield>								
										<subfield code="y">
											<xsl:value-of select="thumbnail/@xlink:href"/>
										</subfield>
										<xsl:if test="@restrictedImage='true'">
											<subfield code="x">
												<xsl:value-of select="@restrictedImage"/>
											</subfield>									
										</xsl:if>
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
										<subfield code="9">
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
									
									<xsl:for-each select="notes|note">
										<subfield code="e">
											<xsl:value-of select="."/>
										</subfield>
									</xsl:for-each>
									
									<xsl:for-each select="relatedInformation">
										<subfield code="6">
											<xsl:value-of select="text"/>
											<xsl:text>--</xsl:text>
											<xsl:value-of select="@href"/>
											<xsl:value-of select="link"/>
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
										<subfield code="l">
											<xsl:if test="type">
												<xsl:value-of select="type"/>
												<xsl:text>: </xsl:text>
											</xsl:if>
											<xsl:value-of select="textElement"/>
										</subfield>			
									</xsl:for-each>

									<xsl:for-each select="image/caption">
										<subfield code="l">
											<xsl:value-of select="."/>
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
											<xsl:if test="dates">
												<xsl:text>, </xsl:text>
												<xsl:value-of select="dates"/>
											</xsl:if>
											<xsl:if test="role">
												<xsl:text> [</xsl:text>
												<xsl:value-of select="role"/>
												<xsl:text>]</xsl:text>
											</xsl:if>
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
									
									<xsl:for-each select="standardizedRights">
										<subfield code="q">
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
											<xsl:if test="dates">
												<xsl:text>, </xsl:text>
												<xsl:value-of select="dates"/>
											</xsl:if>
											<xsl:if test="role">
												<xsl:text> [</xsl:text>
												<xsl:value-of select="role"/>
												<xsl:text>]</xsl:text>
											</xsl:if>
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
											<xsl:if test="dates">
												<xsl:text>, </xsl:text>
												<xsl:value-of select="dates"/>
											</xsl:if>
											<xsl:if test="role">
												<xsl:text> [</xsl:text>
												<xsl:value-of select="role"/>
												<xsl:text>]</xsl:text>
											</xsl:if>
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
									
									<!-- <xsl:for-each select="hvd_structuredDate">
										<subfield code="d">
											<xsl:value-of select="beginDate"/>
											<xsl:text>-</xsl:text>
											<xsl:value-of select="endDate"/>
										</subfield>
									</xsl:for-each> -->
									
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
											<xsl:if test="dates">
												<xsl:text>, </xsl:text>
												<xsl:value-of select="dates"/>
											</xsl:if>
											<xsl:if test="role">
												<xsl:text> [</xsl:text>
												<xsl:value-of select="role"/>
												<xsl:text>]</xsl:text>
											</xsl:if>
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
									
									<xsl:for-each select="subjectPlace/coordinates|hvd_subjectPlace/coordinates">
									<subfield code="o">										
										<xsl:if test="latitude">
											<xsl:text>~lat </xsl:text>
											<xsl:if test="latitude/@decimal">
												<xsl:text>decimal="</xsl:text>
												<xsl:value-of select="latitude/@decimal"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="latitude/@degree">
												<xsl:text>degree="</xsl:text>
												<xsl:value-of select="latitude/@degree"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="latitude/@minute">
												<xsl:text>minute="</xsl:text>
												<xsl:value-of select="latitude/@minute"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="latitude/@second">
												<xsl:text>second="</xsl:text>
												<xsl:value-of select="latitude/@second"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="latitude/@direction">
												<xsl:text>direction="</xsl:text>
												<xsl:value-of select="latitude/@direction"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
										</xsl:if>
										<xsl:if test="longitude">
											<xsl:text>~long </xsl:text>
											<xsl:if test="longitude/@decimal">
												<xsl:text>decimal="</xsl:text>
												<xsl:value-of select="longitude/@decimal"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="longitude/@degree">
												<xsl:text>degree="</xsl:text>
												<xsl:value-of select="longitude/@degree"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="longitude/@minute">
												<xsl:text>minute="</xsl:text>
												<xsl:value-of select="longitude/@minute"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="longitude/@second">
												<xsl:text>second="</xsl:text>
												<xsl:value-of select="longitude/@second"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
											<xsl:if test="longitude/@direction">
												<xsl:text>direction="</xsl:text>
												<xsl:value-of select="longitude/@direction"/>
												<xsl:text>" </xsl:text>
											</xsl:if>
										</xsl:if>
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