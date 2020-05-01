import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyBottlecapsComponent } from './my-bottlecaps.component';

describe('MyBottlecapsComponent', () => {
  let component: MyBottlecapsComponent;
  let fixture: ComponentFixture<MyBottlecapsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyBottlecapsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyBottlecapsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
