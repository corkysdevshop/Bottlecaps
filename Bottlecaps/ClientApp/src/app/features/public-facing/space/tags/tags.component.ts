import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BottlecapService } from '../../../private/my-bottlecaps/bottlecap.service';
import { Tag } from '../../../../shared/models';

@Component({
  selector: 'app-tags',
  templateUrl: './tags.component.html',
  styleUrls: ['./tags.component.css']
})
export class TagsComponent implements OnInit {
	public tags: Tag[];
	//constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
	//	http.get<Tag[]>(baseUrl + 'api/Tags').subscribe(result => {
	//		console.log('success: ', result);
	//		this.tags = result;
	//	}, error => console.error("error", error));
	//}
	constructor(private bottlecapService: BottlecapService) {
		//bottlecapService.getSpaceTags()
	}
	ngOnInit() {
	}

}


//interface Tag {
//	TagId: number;
//	TagText: string;
//	BottlecapId: number;
//}
