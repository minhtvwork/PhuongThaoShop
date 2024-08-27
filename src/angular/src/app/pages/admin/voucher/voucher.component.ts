import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from '../../../shared/services/admin.service';
import { NzModalService } from 'ng-zorro-antd/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { VoucherDto} from 'src/app/shared/models/model';
import { NzMessageService } from 'ng-zorro-antd/message';
@Component({
  selector: 'app-voucher',
  templateUrl: './voucher.component.html',
  styleUrls: ['./voucher.component.scss']
})
export class VoucherComponent implements OnInit {
  isVisible = false;
  isSave = false;
  modalTitle = 'Thêm';
  listData: VoucherDto[] = [];
  fbForm!: FormGroup;
  searchKeyword = '';
  constructor(private adminService: AdminService, private router: Router, private modal: NzModalService, private nzMessageService: NzMessageService, private fb: FormBuilder) {}
  ngOnInit(): void {
    this.fbForm = this.fb.group({
      id: 0,
      maVoucher: ['', [Validators.required]],
      tenVoucher: ['', [Validators.required]],
      startDay: [null, [Validators.required]],
      endDay: [null, [Validators.required]],
      giaTri: [0, [Validators.required]],
      soLuong: [0, [Validators.required]],
      status: [0, [Validators.required]],
    });
    this.loadData();
  }
  loadData(): void {
    this.adminService.getPageVoucher(1, 99999, this.searchKeyword).subscribe(response => {
      console.log(response.data)
      this.listData = response.data;
    });
  }
  search(): void {
    this.loadData();  // Reload and filter the data based on the keyword
  }
  create(): void {
    this.modalTitle = 'Thêm ';
    this.fbForm.reset({
      id: '0'
    });
    this.isVisible = true;
  }
  save(): void {
    if (this.fbForm.valid) {
      const obj = this.fbForm.value;
      this.isSave = true;
      const startDay: Date = new Date(obj.startDay);
const endDay: Date = new Date(obj.endDay);
      this.adminService.createOrUpdateVoucher(obj.id,obj.maVoucher, obj.tenVoucher,startDay,endDay,obj.giaTri,obj.soLuong,obj.status).subscribe(
        (response: any) => {
          if (response.succeeded) {
            this.nzMessageService.success(response.messages);
            this.isSave = false;
            this.isVisible = false;
            this.loadData();
            this.fbForm.reset({ id: '0' });
          } else {
            this.nzMessageService.error(response.messages);
            this.isSave = false;
          }
        },
        (error) => {
          this.isSave = false;
          this.nzMessageService.error('Thất bại');
          console.error('API call failed:', error);
        }
      );
    }
    else {
      this.nzMessageService.error('Hãy nhập đầy đủ giá trị');
    }
  }

  close(): void {
    this.isVisible = false;
  }
  cancel(): void {
    this.nzMessageService.info('Bạn đã hủy thao tác');
  }
  edit(item: VoucherDto): void {
    this.modalTitle = 'Sửa ';
    this.fbForm.patchValue(item);
    this.isVisible = true;
  }

  delete(id: number): void {
    this.adminService.deleteVoucher(id).subscribe(
      (response: any) => {
        if (response.succeeded) {
          this.nzMessageService.success('Thành công');
          this.loadData();
        } else {
          this.nzMessageService.error('Thất bại');
        }
      },
      (error) => {
        this.nzMessageService.error('Thất bại');
        console.error('API call failed:', error);
      }
    );
  }
}
