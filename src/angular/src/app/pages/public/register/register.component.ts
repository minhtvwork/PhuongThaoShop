import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { AccountService } from 'src/app/shared/services/account.service';
import { NzMessageService } from 'ng-zorro-antd/message';
import { Router } from '@angular/router';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})
export class RegisterComponent {
  registerForm: FormGroup;

  constructor(private fb: FormBuilder, private accountService: AccountService,private nzMessageService: NzMessageService,private router: Router) {
    this.registerForm = this.fb.group({
      userName: ['', Validators.required],
      fullName: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required, this.confirmationValidator]]
    });
  }

  // Chỉ giữ lại một hàm confirmationValidator với kiểu chính xác
  confirmationValidator = (control: FormControl): { [s: string]: boolean } | null => {
    if (!control.value) {
      return { required: true };
    } else if (control.value !== this.registerForm.controls['password'].value) {
      return { confirm: true };
    }
    return null;
  };

  submitForm(): void {
    if (this.registerForm.valid) {
      var obj = this.registerForm.value
      this.accountService.register(this.registerForm.value).subscribe(
        response => {
          this.nzMessageService.success('Đăng ký thành công!');
          this.router.navigate(['/']);
          this.accountService.login(obj.userName,obj.password).subscribe(
            response => {
              if(response.isSuccess){
                window.location.reload();
              }
              this.nzMessageService.info('Tài khoản hoặc mật khẩu sai ');
            },
            error => {
              this.nzMessageService.info('Tài khoản hoặc mật khẩu sai ');
              console.error(error);
            }
          );
         
        },
        error => {
          this.nzMessageService.error(error.error);
          console.log(error.error); 
        }
      );
    } else {
      this.nzMessageService.error('Form không hợp lệ!');
      console.log('Form không hợp lệ!');
    }
  }
  
}
