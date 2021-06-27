import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClasamentComponent } from './clasament.component';

describe('ClasamentComponent', () => {
  let component: ClasamentComponent;
  let fixture: ComponentFixture<ClasamentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClasamentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClasamentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
