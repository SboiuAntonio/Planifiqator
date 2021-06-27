import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CautaDestinatiiComponent } from './cauta-destinatii.component';

describe('CautaDestinatiiComponent', () => {
  let component: CautaDestinatiiComponent;
  let fixture: ComponentFixture<CautaDestinatiiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CautaDestinatiiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CautaDestinatiiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
