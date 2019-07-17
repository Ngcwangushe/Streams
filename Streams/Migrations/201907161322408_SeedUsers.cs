namespace Streams.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'452daad3-86a6-43f6-bd59-d4607eb83ff4', N'admin@streams.com', 0, N'AIUSYMjPc5ynsEZwdUB7g5oaWYabU5Hsx/dHbUogOp5swiA5gBf0RyEp9iCKN2BXcQ==', N'bea6da99-83fb-460d-9f6f-75609439272e', NULL, 0, 0, NULL, 1, 0, N'admin@streams.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd4e3ba97-069e-4552-82e4-4860ce5a76f2', N'guest@streams.com', 0, N'APiV4FBEhyVBG8eRGJnGLTzbg+PmQdajfTqPR0Rcq0FW7hdrMzzqXXrZ4ROprVoZAQ==', N'99b20f15-97a1-4606-b39a-d5942525a22d', NULL, 0, 0, NULL, 1, 0, N'guest@streams.com')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'97aa154a-72fc-45d7-a50b-39fba878f6df', N'CanManageMovies')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'452daad3-86a6-43f6-bd59-d4607eb83ff4', N'97aa154a-72fc-45d7-a50b-39fba878f6df')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
