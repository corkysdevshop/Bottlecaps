import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../shared/auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
	styleUrls: ['./auth.component.css'],
  providers: [AuthService]
})
export class AuthComponent implements OnInit {

	constructor(private authService: AuthService) {}

	ngOnInit() {	}

	logIn(formData) {
		console.log("auth.comp.ts", formData);
		this.authService.login(formData);
	}

	register(formData) {
		//console.log('in onSubmit', formData);
		this.authService.register(formData);
	}
}
