<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet 
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    version="1.0">
	
	<xsl:output method="xml" indent="yes" encoding="UTF-8"/>

	 <xsl:template match="/">
        <xsl:apply-templates select="record"/>
      </xsl:template>

	<xsl:template match="record/layer_list">		

		<xsl:for-each select="layer">
			<datafield tag="597" ind1=" " ind2="9">
				<subfield code="c">
					<xsl:value-of select="layer_title"/>
				</subfield>
				<subfield code="d">
					<xsl:value-of select="layer_id"/>
				</subfield>
			</datafield>
		</xsl:for-each>						

	</xsl:template>	

</xsl:stylesheet>