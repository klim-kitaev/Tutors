import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PupilListEditComponent } from './pupil-list-edit.component';

describe('PupilListEditComponent', () => {
  let component: PupilListEditComponent;
  let fixture: ComponentFixture<PupilListEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PupilListEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PupilListEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
