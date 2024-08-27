import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from '../../../shared/services/admin.service';
import { NzModalService } from 'ng-zorro-antd/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ColorDto } from 'src/app/shared/models/model';
import { NzMessageService } from 'ng-zorro-antd/message';

@Component({
  selector: 'app-color',
  templateUrl: './color.component.html',
  styleUrls: ['./color.component.scss']
})
export class ColorComponent implements OnInit {
  isVisible = false;
  isSave = false;
  modalTitle = 'Thêm';
  listData: ColorDto[] = [];
  fbForm!: FormGroup;
  searchKeyword = '';
  constructor(private adminService: AdminService, private router: Router, private modal: NzModalService, private nzMessageService: NzMessageService, private fb: FormBuilder) { }
  ngOnInit(): void {
    this.fbForm = this.fb.group({
      id: 0,
      ma: ['', [Validators.required]],
      name: ['', [Validators.required]],
    });
    this.loadData();
  }
  loadData(): void {
    this.adminService.getPageColor(1, 99999, this.searchKeyword).subscribe(response => {
      this.listData = response.data;
    });
  }
  search(): void {
    this.loadData();
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
      this.adminService.createOrUpdateColor(obj.id, obj.ma, obj.name).subscribe(
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
  edit(item: ColorDto): void {
    this.modalTitle = 'Sửa ';
    this.fbForm.patchValue(item);
    this.isVisible = true;
  }

  delete(id: number): void {
    this.adminService.deleteColor(id).subscribe(
      (response: any) => {
        console.log(response)
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
