export class Tag {
	public tagText: string;
	constructor(public TagText: string) {
		this.tagText = TagText;
	}
}

export class Link {
	public linkText: string;
	constructor(public LinkText: string) {
		this.linkText = LinkText;
	}
}

export class Bottlecap {
	public bottlecapId?: number;
	public title: string;
	public tag: Tag[];
	public link: Link[];
	public profile: Profile;

	constructor(title: string, tags: Tag[], links: Link[], profile: Profile) {
		this.title = title;
		this.tag = tags;
		this.link = links;
		this.profile = profile;
	}
}

export class Profile {
	public ProfileId: number;
	constructor(public profileId: number) {
		this.ProfileId = profileId;
	}
}

export class Space {
	public SpaceId?: string;
	public SpaceName: string;
	public ActiveStatus: string;
	public BackgroundImage: string;
	public DefaultBottlecapId: string;
	public ProfileId: string;
}

