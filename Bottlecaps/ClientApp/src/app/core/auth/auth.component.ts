import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../shared/auth.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
	styleUrls: ['./auth.component.css'],
  providers: [AuthService]
})
export class AuthComponent implements OnInit {

  formRegister

	constructor(private authService: AuthService, private formBuider: FormBuilder) {
		this.formRegister = formBuider.group({
			email: ['', Validators.required],
      password: ['', Validators.required]
		})
		this.formLogin = formBuider.group({
			email: ['', Validators.required],
			password: ['', Validators.required]
		})
	}

	ngOnInit() {	}

	logIn(formData) {
		console.log("auth.comp.ts", formData);
		this.authService.login(formData);
	}
}
