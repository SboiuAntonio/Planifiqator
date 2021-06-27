import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanificariComponent } from './planificari.component';

describe('PlanificariComponent', () => {
  let component: PlanificariComponent;
  let fixture: ComponentFixture<PlanificariComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlanificariComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanificariComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
