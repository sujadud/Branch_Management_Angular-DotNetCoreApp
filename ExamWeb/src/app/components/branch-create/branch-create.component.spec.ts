import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BranchCreateComponent } from './branch-create.component';

describe('BranchCreateComponent', () => {
  let component: BranchCreateComponent;
  let fixture: ComponentFixture<BranchCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BranchCreateComponent]
    });
    fixture = TestBed.createComponent(BranchCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
