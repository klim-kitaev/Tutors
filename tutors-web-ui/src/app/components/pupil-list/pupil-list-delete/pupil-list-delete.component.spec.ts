import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PupilListDeleteComponent } from './pupil-list-delete.component';

describe('PupilListDeleteComponent', () => {
  let component: PupilListDeleteComponent;
  let fixture: ComponentFixture<PupilListDeleteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PupilListDeleteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PupilListDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
