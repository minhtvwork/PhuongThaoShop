import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageBillV1Component } from './manage-bill-v1.component';

describe('ManageBillComponent', () => {
  let component: ManageBillV1Component;
  let fixture: ComponentFixture<ManageBillV1Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ManageBillV1Component]
    });
    fixture = TestBed.createComponent(ManageBillV1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
