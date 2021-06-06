<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="text"/>
  <xsl:template match="/">
    <xsl:apply-templates select="//Day"/>
  </xsl:template>
  <xsl:template match="Day">
    <xsl:text>День недели: </xsl:text>
    <xsl:value-of select="DayName"/>
    <xsl:apply-templates select="Subjects/Subject"/>
    <xsl:text>&#xa;</xsl:text>
  </xsl:template>
  <xsl:template match="Subject">
    <xsl:text>&#xa;</xsl:text>
    <xsl:text>  Предмет: </xsl:text>
    <xsl:value-of select="Name"/>
    <xsl:text>&#xa;</xsl:text>
    <xsl:text>    Аудитория: </xsl:text>
    <xsl:value-of select="LectureHall"/>
    <xsl:text>&#xa;</xsl:text>
    <xsl:text>    Преподаватель: </xsl:text>
    <xsl:value-of select="Teacher"/>
    <xsl:text>&#xa;</xsl:text>
    <xsl:text>    Тип занятия: </xsl:text>
    <xsl:value-of select="Type"/>
    <xsl:text>&#xa;</xsl:text>
    <xsl:text>    Начало заятия: </xsl:text>
    <xsl:value-of select="StartTime"/>
    <xsl:text>&#xa;</xsl:text>
    <xsl:text>    Окончание занятия: </xsl:text>
    <xsl:value-of select="EndTime"/>
    <xsl:text>&#xa;</xsl:text>
  </xsl:template>
</xsl:stylesheet>