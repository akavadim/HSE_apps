<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html"/>
  <xsl:template match="/">
    <html>
      <body>
        <table border="1">
          <caption>Расписание</caption>
          <tr>
            <th>Предмет</th>
            <th>Аудитория</th>
            <th>Преподаватель</th>
            <th>Тип занятия</th>
            <th>Время начала</th>
            <th>Время окончания</th>
          </tr>
          <xsl:apply-templates select="//Day"/>
        </table>
      </body>
    </html>
  </xsl:template>
  <xsl:template match="Day">
    <tr>
      <td colspan="6" align="Center">
        <xsl:value-of select="DayName"/>
      </td>
    </tr>
    <xsl:apply-templates select="Subjects/Subject"/>
  </xsl:template>
  <xsl:template match="Subject">
    <tr>
      <td><xsl:value-of select="Name"/></td>
      <td><xsl:value-of select="LectureHall"/></td>
      <td><xsl:value-of select="Teacher"/></td>
      <td><xsl:value-of select="Type"/></td>
      <td><xsl:value-of select="StartTime"/></td>
      <td><xsl:value-of select="EndTime"/></td>
    </tr>
  </xsl:template>
</xsl:stylesheet>