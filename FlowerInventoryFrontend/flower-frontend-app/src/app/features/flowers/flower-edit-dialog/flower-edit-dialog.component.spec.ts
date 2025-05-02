import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlowerEditDialogComponent } from './flower-edit-dialog.component';

describe('FlowerEditDialogComponent', () => {
  let component: FlowerEditDialogComponent;
  let fixture: ComponentFixture<FlowerEditDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FlowerEditDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FlowerEditDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
