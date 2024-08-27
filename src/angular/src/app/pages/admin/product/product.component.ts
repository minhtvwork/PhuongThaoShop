import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from '../../../shared/services/admin.service';
import { NzModalService } from 'ng-zorro-antd/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductDto,ManufacturerDto,ProductTypeDto} from 'src/app/shared/models/model';
import { NzMessageService } from 'ng-zorro-antd/message';
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  isVisible = false;
  isSave = false;
  modalTitle = 'Thêm';
  listData: ProductDto[] = [];
  fbForm!: FormGroup;
  manufacturers: ManufacturerDto[] = [];
  productTypes: ProductTypeDto[] = [];
  searchKeyword = '';
  constructor(private adminService: AdminService, private router: Router, private modal: NzModalService, private nzMessageService: NzMessageService, private fb: FormBuilder) {}
  ngOnInit(): void {
    this.fbForm = this.fb.group({
      id: 0,
      name: ['', [Validators.required]],
      manufacturerEntityId: [0, [Validators.required]],
      productTypeEntityId: [0, [Validators.required]],
    });
    this.loadData();
    this.adminService.getListProductType().subscribe(data => {
      this.productTypes = data.data;
    });
    this.adminService.getListManufacturer().subscribe(data => {
      
      this.manufacturers = data.data;
    });
  }
  loadData(): void {
    this.adminService.getPageProduct(1, 99999, this.searchKeyword).subscribe(response => {
      console.log(response.data)
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
      this.adminService.createOrUpdateProduct(obj.id,obj.name, obj.manufacturerEntityId, obj.productTypeEntityId).subscribe(
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
  edit(item: ProductDto): void {
    this.modalTitle = 'Sửa ';
    this.fbForm.patchValue(item);
    this.isVisible = true;
  }

  delete(id: number): void {
    this.adminService.deleteBill(id).subscribe(
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
