﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ReportsCore.Models {
    public partial class ObjType {
        [Key]
        [Column("ObjTypeID")]
        public int ObjTypeId { get; set; }
        public int OrderNumber { get; set; }
        [Required]
        [StringLength(128)]
        public string ObjTypeName { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public bool RecordDeleted { get; set; }
        [NotMapped]
        public Brush ObjTypeBrush { get; set; }
        private System.Drawing.Color _ObjTypeColor { get; set; }
        [NotMapped]
        public System.Drawing.Color ObjTypeColor {
            get {
                if (ObjTypeBrush != null) {
                    byte a = ((Color)ObjTypeBrush.GetValue(SolidColorBrush.ColorProperty)).A;
                    byte g = ((Color)ObjTypeBrush.GetValue(SolidColorBrush.ColorProperty)).G;
                    byte r = ((Color)ObjTypeBrush.GetValue(SolidColorBrush.ColorProperty)).R;
                    byte b = ((Color)ObjTypeBrush.GetValue(SolidColorBrush.ColorProperty)).B;
                    return System.Drawing.Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                }
                return System.Drawing.Color.FromArgb((byte)255, (byte)255, (byte)255, (byte)255);
            }
        }
        //public bool IsChecked { get; set; }

        //private Color _ObjTypeColor { get; set; }
        //[NotMapped]
        //public Color ObjTypeColor {
        //    get => _ObjTypeColor;
        //    set {
        //        Random r = new Random();
        //        r.Next(0, 255);
        //        _ObjTypeColor = Color.FromArgb((byte)r.Next(0, 255), (byte)r.Next(0, 255), (byte)r.Next(0, 255), (byte)r.Next(0, 255));
        //    }
        //}
    }
}