import { Component, OnInit, HostListener, ElementRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, NonNullableFormBuilder, Validators } from '@angular/forms';
import { AccountService } from 'src/app/shared/services/account.service';
import { NzMessageService } from 'ng-zorro-antd/message';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  @ViewChild('menuHeader') menuHeader!: ElementRef;
  @ViewChild('menuMainAll') menuMainAll!: ElementRef;
  @ViewChild('mobileHeader') mobileHeader!: ElementRef;
  @ViewChild('scrollMenuX') scrollMenuX!: ElementRef;
  lastPosition: number = 0;
  siteheadermobi: number = 0;
  menuOffsetTop: number = 0;

  tabItems = [
    { label: 'Tab 1', id: 'tab1' },
    { label: 'Tab 2', id: 'tab2' },
    // Add more tabs as needed
  ];

  tabContents = [
    { id: 'tab1', content: 'Content for Tab 1' },
    { id: 'tab2', content: 'Content for Tab 2' },
    // Add more contents as needed
  ];
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
  @HostListener('window:scroll', ['$event'])
  onWindowScroll() {
    const scrollTop = window.pageYOffset || document.documentElement.scrollTop;

    if (scrollTop >= this.menuHeader.nativeElement.offsetTop + 1) {
      this.menuHeader.nativeElement.classList.add('stickyhead');
    } else {
      this.menuHeader.nativeElement.classList.remove('stickyhead');
    }

    if (scrollTop >= this.menuMainAll.nativeElement.offsetTop + 307) {
      this.menuMainAll.nativeElement.classList.add('stickymenub');
    } else {
      this.menuMainAll.nativeElement.classList.remove('stickymenub');
    }

    if (scrollTop > this.lastPosition) {
      if (scrollTop > this.menuOffsetTop + 50) {
        this.mobileHeader.nativeElement.classList.remove('nav_show');
        this.mobileHeader.nativeElement.classList.add('nav_hidden');
      }
    } else {
      if (scrollTop > this.menuOffsetTop) {
        this.mobileHeader.nativeElement.classList.remove('nav_hidden');
        this.mobileHeader.nativeElement.classList.add('nav_show');
      } else {
        this.mobileHeader.nativeElement.classList.remove('nav_hidden');
        this.mobileHeader.nativeElement.classList.remove('nav_show');
      }
    }

    this.lastPosition = scrollTop;
  }

  toggleMenu() {
    this.menuMainAll.nativeElement.classList.toggle('show-menu-all');
    document.body.classList.toggle('m-overflow');
  }

  closeMenu() {
    this.menuMainAll.nativeElement.classList.remove('show-menu-all');
    document.body.classList.remove('m-overflow');
  }

  showMenu(event: any) {
    const parent = event.target.closest('.menu-column');
    parent.querySelector('.menu-nav-cat').classList.add('max-hight');
  }

  hideMenu(event: any) {
    const parent = event.target.closest('.menu-column');
    parent.querySelector('.menu-nav-cat').classList.remove('max-hight');
  }

  toggleMobileMenu() {
    this.mobileHeader.nativeElement.classList.toggle('show-menubar');
    document.querySelector('.m-ic-down')?.classList.toggle('fx-down');
  }

  toggleSearch() {
    document.querySelector('.search-box')?.classList.toggle('show-search-all');
  }

  closeSearch() {
    document.querySelector('.search-box')?.classList.remove('show-search-all');
  }

  toggleMobileSearch() {
    document.querySelector('.search-box-m')?.classList.toggle('show-search-all-m');
  }

  closeMobileSearch() {
    document.querySelector('.search-box-m')?.classList.remove('show-search-all-m');
  }

  scrollMenu(direction: string) {
    const scrollValue = 50;
    const currentScroll = this.scrollMenuX.nativeElement.scrollLeft;

    if (direction === 'next') {
      this.scrollMenuX.nativeElement.scrollLeft = currentScroll + scrollValue;
    } else if (direction === 'previous') {
      this.scrollMenuX.nativeElement.scrollLeft = currentScroll - scrollValue;
    }
  }

  showPopup() {
    document.body.classList.add('body-hiden');
  }

  closePopup() {
    document.body.classList.remove('body-hiden');
  }

  hideMore(event: any) {
    const parent = event.target.closest('.block-podcast-content');
    parent.querySelector('.w-conten-podcast').classList.add('max-height');
  }

  viewMore(event: any) {
    const parent = event.target.closest('.block-podcast-content');
    parent.querySelector('.w-conten-podcast').classList.remove('max-height');
  }

  openTab(item: any) {
    this.tabItems.forEach(el => document.getElementById(el.id)?.classList.remove('active'));
    this.tabContents.forEach(el => document.getElementById(el.id)?.classList.remove('active'));

    document.getElementById(item.id)?.classList.add('active');
    document.querySelector(`[data-electronic="${item.id}"]`)?.classList.add('active');
  }
}
