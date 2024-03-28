import { Component } from '@angular/core';
import { FormControl, FormGroup, NonNullableFormBuilder, Validators } from '@angular/forms';
import { AccountService } from 'src/app/shared/services/account.service';
import { NzMessageService } from 'ng-zorro-antd/message';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  isVisible = false;
  isOkLoading = false;
  username: string | null = null;
  constructor(private accountService: AccountService,private fb: NonNullableFormBuilder, private nzMessageService: NzMessageService) {
    const currentUserString = localStorage.getItem('currentUser');
    if (currentUserString) {
      const currentUser = JSON.parse(currentUserString);
      this.username = currentUser.username;
    }
  }
  showModal(): void {
    
    this.isVisible = true;
  }
  handleCancel(): void {
    this.isVisible = false;
  }
  loginForm: FormGroup<{
    username: FormControl<string>;
    password: FormControl<string>;
    remember: FormControl<boolean>;
  }> = this.fb.group({
    username: ['', [Validators.required]],
    password: ['', [Validators.required]],
    remember: [true]
  });

  submitForm(): void {
    if (this.loginForm.valid) {
      console.log('submit', this.loginForm.value);
      const username = this.loginForm.get('username')!.value;
      const password = this.loginForm.get('password')!.value;
      
      this.accountService.login(username, password).subscribe(
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
    } else {
      Object.values(this.loginForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }
  
  logOut(): void {
   this.accountService.logout();
   window.location.reload();
  }

}
