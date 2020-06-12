import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'

//@Injectable({
//  providedIn: 'root'
//})

@Injectable()
export class AuthService {
	baseUrl;
	constructor(private http: HttpClient, private router: Router, @Inject('BASE_URL') baseUrl: string) {
		this.baseUrl = baseUrl;
	}

	get isAuthenticated() {
		return !!localStorage.getItem('token')
	}

	register(credentials) {
		this.http.post<any>(`api/account`, credentials).subscribe(data => {
			  this.authenticate(data);
			},
			error => {
				console.log('error: ', error);
			},
			() => {
				console.log('completed');
			}
		)
	}

	login(credentials) {
		this.http.post<any>(`api/account/login`, credentials).subscribe(data => {
			this.authenticate(data);
		},
			error => {
				console.log('error: ', error);
			},
			() => {
				console.log('completed');
			}
		)
	}

	authenticate(res) {
		localStorage.setItem('token', res);
		this.router.navigate(['dashboard']);
	}

	logout() {
		localStorage.removeItem('token') //TODO: RENAME THIS TOKEN TO SOMETHING LESS GENERIC (ALSO WHERE IT'S SET)
		this.router.navigate(['']);
	}
}
