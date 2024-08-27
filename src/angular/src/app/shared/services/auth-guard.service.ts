import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AccountService } from '../services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private accountService: AccountService, private router: Router) { }

  async canActivate(): Promise<boolean> {
    const currentUserString = localStorage.getItem('currentUser');
    if (currentUserString) {
      const currentUser = JSON.parse(currentUserString);
      const token = currentUser.accessToken;

      if (token) {
        try {
          const roles = await this.accountService.getUserRoles().toPromise();
          if (Array.isArray(roles) && (roles.includes('Admin') || roles.includes('Employee'))) {
            return true;
          }
        } catch (error) {
          console.error('Error checking user roles', error);
        }
      }
    }

    // Điều hướng đến trang đăng nhập nếu người dùng không có quyền
    await this.router.navigateByUrl('/login', { skipLocationChange: true });
    return false;
  }
}
