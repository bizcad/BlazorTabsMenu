﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlazorTabsMenu.Models;

public partial class Topic
{
    [Key]
    public Guid Id { get; set; }

    public string TopicName { get; set; } = null!;

    public string? TopicHeader { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Sequence { get; set; }

    public int TabNumber { get; set; }

    public string? Description { get; set; }

    public string? HelpText { get; set; }

    public string? TopicFooter { get; set; }

    [StringLength(254)]
    [Unicode(false)]
    public string? TopicNavPage { get; set; }
}