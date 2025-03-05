import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BranchUpdateComponent } from './branch-update.component';

describe('BranchUpdateComponent', () => {
  let component: BranchUpdateComponent;
  let fixture: ComponentFixture<BranchUpdateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BranchUpdateComponent]
    });
    fixture = TestBed.createComponent(BranchUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
