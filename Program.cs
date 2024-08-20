using LibrarySoft.Core.DTOS;
using LibrarySoft.Core.Services;
using LibrarySoft.Services;

Console.WriteLine("Libray Management System");
Console.WriteLine("Press\n1 to Add Data\n2 to Delete Data\n3  to Update Data\n4 to get all Members    ");
var counter = Convert.ToInt32(Console.ReadLine());  

switch (counter)
{
     case 1:
        {
            Console.WriteLine("Add Data");
            Console.Write("Member Name :");
            var memberName = Console.ReadLine();
            MemberDto memberDto = new MemberDto(1, memberName, DateTime.Now);
            IMemberService memberService = new MemberService();
            await memberService.AddMemberAsync(memberDto);

            break;
        }
     case 2:
        {
            Console.WriteLine("Delete Data");
            Console.Write("member Id :");
            var member_ID = Convert.ToByte(Console.ReadLine());
            IMemberService memberService = new MemberService();
            await memberService.DeleteMemberAsync(member_ID);
            break;
        }
    case 3:
        {
        Console.WriteLine("Update Data");
        Console.Write("member ID :  ");
        var memberID = Convert.ToByte(Console.ReadLine());
        Console.Write("name : ");
        var memberName = Console.ReadLine();
        MemberDto memberDtoUpdate = new MemberDto(memberID, memberName, DateTime.Now);
        IMemberService memberServiceUpdate = new MemberService();
        await memberServiceUpdate.UpdateMemberAsync(memberDtoUpdate);
        break;
        }
    case 4:
        {
            Console.WriteLine("Get All Data");
           IMemberService memberService = new MemberService();
           List<MemberDto> members =  await memberService.GetMemberAsync();

            foreach( var mem in members)
            {
                Console.Write(mem.MemberId+"  " +mem.Name + "  " + mem.MembershipDate + "  " + "\n");
            }
            break;
        }

}