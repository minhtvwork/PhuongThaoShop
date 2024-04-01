import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../../shared/services/admin.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { VoucherDto,VoucherCreateDto } from '../../../shared/models/model';
@Component({
  selector: 'app-voucher',
  templateUrl: './voucher.component.html',
  styleUrls: ['./voucher.component.scss']
})
export class VoucherComponent implements OnInit {
  dataInput!: VoucherCreateDto; // Khởi tạo thuộc tính dataInput
  rfDataModal: FormGroup = this.formBuilder.group({});
  saving = false;
  isEditModalVisible = false;
  loading = true;
  pageSize = 10;
  pageIndex = 1;
  total = 1;
  listOfData: VoucherDto[] = [];
  productId!: string;

  constructor(private adminService: AdminService, private formBuilder: FormBuilder) { }
  ngOnInit(): void {
    this.loadVouchers();
  }
  loadVouchers(): void {
    this.loading = true;
    const sorting = ''; // You can add sorting logic here if needed
    this.adminService.getVouchers(this.pageIndex, this.pageSize, sorting)
      .subscribe(result => {
        this.listOfData = result.items;
        this.total = result.totalCount;
        this.loading = false;
      }, error => {
        console.error('Error fetching vouchers:', error);
        this.loading = false;
      });
  }
  openEditModal(): void {
    this.isEditModalVisible = true; 
  }
  closeEditModal(): void {
    this.isEditModalVisible = false;
  }
  handleEdit(): void {
    this.closeEditModal();
  }
}
