import { Component, OnInit } from '@angular/core';
import { PublicService } from '../../../shared/services/public.service';
import { AccountService } from 'src/app/shared/services/account.service';
import { CartItemDto, PBillCreateCommand, ResponseDto, VoucherDto, ApiResult, PBillGetByCodeQueryDto, AddressDto, UserDto } from '../../../shared/models/model';
import { Router, ActivatedRoute } from '@angular/router';
import { AdminService } from '../../../shared/services/admin.service';
import { NzModalService } from 'ng-zorro-antd/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd/message';
@Component({
  selector: 'app-customer-info',
  templateUrl: './customer-info.component.html',
  styleUrls: ['./customer-info.component.scss']
})
export class CustomerInfoComponent implements OnInit {
  customer: UserDto = {
    id: this.accountService.getUserId(),
    userName: '',
    email: '',
    phoneNumber: '',
    fullName:''
  };
  isVisible = false;
  isVisible2 = false;
  isSave = false;
  isSave2 = false;
  modalTitle = 'Thêm';;
  fbForm!: FormGroup;
  userForm!: FormGroup;
  address: AddressDto[] = [];
  provinces: any[] = [];
  districts: any[] = [];
  communes: any[] = [];
  constructor(private publicService: PublicService, private adminService: AdminService, private nzMessageService: NzMessageService, private fb: FormBuilder,
    private accountService: AccountService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.fbForm = this.fb.group({
      id: 0,
      addressName: ['', [Validators.required]],
      province: [null, [Validators.required]],
      district: [null, [Validators.required]],
      commune: [null, [Validators.required]],
      provinceText: [''],
      districtText: [''],
      communeText: [''],
    });
    this.userForm = this.fb.group({
      id: 0,
      fullName: ['', [Validators.required]],
      phoneNumber: ['', [Validators.required]],
      email: ['', [Validators.required]],
    });
    this.loadAddress(this.accountService.getUserId());
    this.loadProvinces();
    this.fbForm.get('province')?.valueChanges.subscribe(provinceId => {
      this.loadDistricts(provinceId);
      this.fbForm.get('district')?.setValue(null);
      this.communes = [];
    });

    this.fbForm.get('district')?.valueChanges.subscribe(districtId => {
      this.loadCommunes(districtId);
      this.fbForm.get('commune')?.setValue(null);
    });
    this.loadCustomerInfo();
  }

  loadCustomerInfo(): void {
    const userId = this.accountService.getUserId(); // Lấy ID người dùng từ accountService
    this.publicService.getUserById(this.accountService.getUserId()).subscribe(
      (response) => {
        this.customer = response.data;
      },
      (error) => {
        this.nzMessageService.error('Không thể tải thông tin người dùng');
        console.error('API call failed:', error);
      }
    );
  }
  editUser(item: UserDto): void {
    this.userForm.patchValue(item);
    this.isVisible2 = true;
  }
  saveUser(): void {
    console.log(this.userForm.value);
    if (this.userForm.valid) {
      this.isSave2 = true;
      const user = this.userForm.value;
  
      this.publicService.createOrUpdateUser(user.id,user.fullName,user.phoneNumber,user.email).subscribe(
        (response: any) => {
          if (response.succeeded) {
            this.nzMessageService.success('Cập nhật thông tin thành công');
            this.customer = user; // Cập nhật lại thông tin người dùng trên giao diện
            this.isSave2 = false;
            this.isVisible2 = false;
          } else {
            this.nzMessageService.error(response.messages);
          }
        },
        (error) => {
          this.nzMessageService.error(error);
          this.isSave2 = false;
          console.error('API call failed:', error);
        }
      );
    } else {
      this.nzMessageService.error('Hãy nhập đầy đủ giá trị hợp lệ');
    }
  }

  closeUser(): void {
    this.isVisible2 = false;
  }

  cancelUser(): void {
    this.nzMessageService.info('Bạn đã hủy thao tác');
  }
  loadAddress(userId: number): void {
    this.publicService.getAddress(userId).subscribe(response => {
      this.address = response.data;
    });
  }
  create(): void {
    this.modalTitle = 'Thêm địa chỉ ';
    this.fbForm.reset({
      id: '0'
    });
    this.isVisible = true;
  }
  save(): void {
    if (this.fbForm.valid) {
      const obj = this.fbForm.value;
      this.isSave = true;
      var address = (obj.addressName || '') + ', ' + (obj.communeText || '') + ', ' + (obj.districtText || '') + ', ' + (obj.provinceText || '');
      this.publicService.createOrUpdateAddress(obj.id, address, this.accountService.getUserId()).subscribe(
        (response: any) => {
          if (response.succeeded) {
            this.nzMessageService.success(response.messages);
            this.isSave = false;
            this.isVisible = false;
            this.loadAddress(this.accountService.getUserId());
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
  edit(item: AddressDto): void {
    this.modalTitle = 'Sửa ';
    this.fbForm.patchValue(item);
    this.isVisible = true;
  }

  delete(id: number): void {
    this.adminService.deleteAddress(id).subscribe(
      (response: any) => {
        if (response.succeeded) {
          this.nzMessageService.success('Thành công');
          this.loadAddress(this.accountService.getUserId());
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

  loadProvinces(): void {
    this.publicService.getProvinces().subscribe(data => {
      this.provinces = data.results;
    });
  }

  loadDistricts(provinceId: string): void {
    this.publicService.getDistricts(provinceId).subscribe(data => {
      this.districts = data.results;
    });
  }

  loadCommunes(districtId: string): void {
    this.publicService.getCommunes(districtId).subscribe(data => {
      this.communes = data.results;
    });
  }
  onProvinceChange(provinceId: number): void {
    const selectedProvince = this.provinces.find(province => province.province_id === provinceId);
    this.fbForm.patchValue({ provinceText: selectedProvince?.province_name });
  }

  onDistrictChange(districtId: number): void {
    const selectedDistrict = this.districts.find(district => district.district_id === districtId);
    this.fbForm.patchValue({ districtText: selectedDistrict?.district_name });
  }

  onCommuneChange(communeId: number): void {
    const selectedCommune = this.communes.find(commune => commune.ward_id === communeId);
    this.fbForm.patchValue({ communeText: selectedCommune?.ward_name });
  }
}
