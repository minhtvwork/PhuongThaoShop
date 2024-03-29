﻿using PTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS.Domain.Dto
{
    public class SanPhamGiamGiaDto
    {
        public int Id { get; set; }
        public decimal DonGia { get; set; }
        public decimal SoTienConLai { get; set; }
        public int TrangThai { get; set; }
        public int ProductDetailId { get; set; }
        public int GiamGiaId { get; set; }
        public int AvailableQuantity { get; set; }
        public string? ProductDetailCode { get; set; }
        public string? ProductDetailName { get; set; }
        public string? GiamGiaCode { get; set; }
        public string? TenSanPham { get; set; }
        public string? LinkImage { get; set; }
        public decimal? GiamGiaPhanTram { get; set; }
        public string? MaRam { get; set; }
        public string? ThongSoRam { get; set; }
        public string? ThongSoHardDrive { get; set; }
        public string? MaHardDrive { get; set; }
        public string? MaCpu { get; set; }
        public string? TenCpu { get; set; }
        public string? NameColor { get; set; }
        public string? MaColor { get; set; }
        public string? NameProduct { get; set; }
        public string? NameManufacturer { get; set; }
        public string? NameProductType { get; set; }
        public string? MaManHinh { get; set; }
        public string? KichCoManHinh { get; set; }
        public string? TanSoManHinh { get; set; }
        public string? ChatLieuManHinh { get; set; }
        public string? MaCardVGA { get; set; }
        public string? TenCardVGA { get; set; }
        public string? ThongSoCardVGA { get; set; }
        public string? Description { get; set; }
        public virtual GiamGiaEntity? GiamGia { get; set; }
        public virtual ProductDetailEntity? ProductDetail { get; set; }
        public List<string>? OtherImages { get; set; }

    }
}
