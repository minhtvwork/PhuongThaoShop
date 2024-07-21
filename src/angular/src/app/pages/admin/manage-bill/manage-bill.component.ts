import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../../shared/services/admin.service';
import { NzModalService } from 'ng-zorro-antd/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BillDto, PagedRequest } from 'src/app/shared/models/model';
import { NzMessageService } from 'ng-zorro-antd/message';

@Component({
  selector: 'app-manage-bill',
  templateUrl: './manage-bill.component.html',
  styleUrls: ['./manage-bill.component.scss']
})
export class ManageBillComponent implements OnInit {
  isVisible = false;
  isSave = false;
  modalTitle = 'Thêm Bill';
  listData: BillDto[] = [];
  fbForm!: FormGroup;
  request: PagedRequest = { skipCount: 0, maxResultCount: 10 };
  listOfCurrentPageData: readonly BillDto[] = [];
  constructor(private adminService: AdminService, private modal: NzModalService, private nzMessageService: NzMessageService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.fbForm = this.fb.group({
      id: '0',
      ma: ['', [Validators.required]],
      thongSo: ['', [Validators.required]]
    });
    this.loadData();
  }

  loadData(): void {
    this.adminService.getPageBill(1,40,'').subscribe(response => {
      console.log(response)
      this.listData = response.data;
    });
  }
  create(): void {
    this.fbForm.reset({
      id: '0'
    });
    this.isVisible = true;
  }
  save(): void {
    // if (this.fbForm.valid) {
    //   const obj = this.fbForm.value;
    //   this.isSave = true;
    //   this.adminService.createOrUpdateBill(obj).subscribe(
    //     (response: any) => {
    //       if (response.isSuccessed) {
    //         this.nzMessageService.success('Thành công');
    //         this.isSave = false;
    //         this.isVisible = false;
    //         this.loadData();
    //         this.fbForm.reset({ id: '0' });
    //       } else {
    //         this.nzMessageService.error('Thất bại');
    //         this.isSave = false;
    //       }
    //     },
    //     (error) => {
    //       this.isSave = false;
    //       this.nzMessageService.error('Thất bại');
    //       console.error('API call failed:', error);
    //     }
    //   );
    // }
  }

  close(): void {
    this.isVisible = false;
  }
  edit(item: BillDto): void {
    this.modalTitle = 'Sửa Bill';
    this.fbForm.patchValue(item);
    this.isVisible = true;
  }

  delete(id: number): void {
    // this.adminService.deleteBill(id).subscribe(
    //   (response: any) => {
    //     if (response.isSuccessed) {
    //       this.nzMessageService.success('Thành công');
    //       this.loadData();
    //     } else {
    //       this.nzMessageService.error('Thất bại');
    //     }
    //   },
    //   (error) => {
    //     this.nzMessageService.error('Thất bại');
    //     console.error('API call failed:', error);
    //   }
    // );
  }
}
