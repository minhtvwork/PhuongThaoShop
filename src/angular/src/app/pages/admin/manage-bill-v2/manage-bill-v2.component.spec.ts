import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageBillV2Component } from './manage-bill-v2.component';

describe('ManageBillComponent', () => {
  let component: ManageBillV2Component;
  let fixture: ComponentFixture<ManageBillV2Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ManageBillV2Component]
    });
    fixture = TestBed.createComponent(ManageBillV2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
