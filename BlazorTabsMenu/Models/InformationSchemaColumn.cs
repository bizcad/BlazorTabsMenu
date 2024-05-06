/*
 * TABLE_CATALOG, TABLE_SCHEMA, TABLE_NAME, COLUMN_NAME, ORDINAL_POSITION, COLUMN_DEFAULT, IS_NULLABLE, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH,  NUMERIC_PRECISION, NUMERIC_PRECISION_RADIX, NUMERIC_SCALE, DATETIME_PRECISION, CHARACTER_SET_NAME
 */
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlazorTabsMenu.Models;


public class InformationSchemaColumn
{    
    public string TableCatalog { get; set; }
    public string TableSchema { get; set; }
    public string TableName { get; set; }
    public string ColumnName { get; set; }
    public int OrdinalPosition { get; set; }
    public string ColumnDefault { get; set; }
    public string IsNullable { get; set; }
    public string DataType { get; set; }
    public int CharacterMaximumLength { get; set; }
    public int? NumericPrecision { get; set; }
    public int? NumericPrecisionRadix { get; set; }
    public int? NumericScale { get; set; }
    public int? DatetimePrecision { get; set; }
    public string CharacterSetName { get; set; }
}

