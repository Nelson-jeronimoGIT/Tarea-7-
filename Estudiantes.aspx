<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estudiantes.aspx.cs" Inherits="pr_web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <form class="d-flex" action="Estudiantes.cs" method="post" >
      <div class="modal" tabindex="-1" id="myModal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                     <h5 class="modal-title">Detalles del Estudiante</h5>
                     <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                       <div class="mb-3">
                       <asp:Label ID="Label1" runat="server" Text="Carnet" CssClass="badge" Font-Size="Large"></asp:Label>
                       <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Eje: E001"></asp:TextBox>
                      </div>
                      <div class="mb-3">
                        <asp:Label ID="Label2" runat="server" Text="Nombres" CssClass="badge" Font-Size="Large"></asp:Label>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Eje: Nombres1 Nombre2"></asp:TextBox>
                      </div>
                      <div class="mb-3">
                        <asp:Label ID="Label3" runat="server" Text="Apellidos" CssClass="badge" Font-Size="Large"></asp:Label>
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Eje: Apellido1 Apellido2"></asp:TextBox>  
                      </div>
                      <div class="mb-3">
                        <asp:Label ID="Label4" runat="server" Text="Direccion" CssClass="badge" Font-Size="Large"></asp:Label>
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="Eje: #casa calle avenida lugar"></asp:TextBox>  
                      </div>
                      <div class="mb-3">
                        <asp:Label ID="Label5" runat="server" Text="Telefono" CssClass="badge" Font-Size="Large"></asp:Label>
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" placeholder="Eje: 5555 5555"></asp:TextBox>  
                      </div>
                      <div class="mb-3">
                         <asp:Label ID="Label6" runat="server" Text="tipo_de_sangre" CssClass="badge" Font-Size="Large"></asp:Label>
                         <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>
                      <div class="mb-3">
                          <asp:Label ID="Label7" runat="server" Text="Fecha Nacimiento" CssClass="badge" Font-Size="Large"></asp:Label>
                          <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" TextMode="Date"></asp:TextBox> 
                      </div>
                          <hr>
                      <div class="modal-footer">
                      <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Salir</button>
                      <asp:Button ID="Button1" runat="server" Text="Crear" CssClass="btn btn-primary" OnClick="btn_crear_Click" />
                      <asp:Button ID="Button2" runat="server" Text="Actualizar" CssClass="btn btn-success"/>
                      <asp:Button ID="Button3" runat="server" CausesValidation="False" CommandName="Delete" Text="Borrar" CssClass="btn btn-danger" />
                      <asp:Label ID="Label8" runat="server" CssClass="badge" Font-Size="Large"></asp:Label>
                      </div>
                    </div>
                  </div>
            </div>
      </div>  
  </form>   
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table-bordered" DataKeyNames="id,id_tipo_de_sangre" OnSelectedIndexChanged="grid_estudiantes_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btn_select" runat="server" CausesValidation="False" CommandName="Select" Text="ver" CssClass="btn btn-info" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btn_borrar" runat="server" CausesValidation="False" CommandName="Delete" Text="Borrar" CssClass="btn btn-danger" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="carnet" HeaderText="Carnet" />
            <asp:BoundField DataField="nombres" HeaderText="Nombres" />
            <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
            <asp:BoundField DataField="direccion" HeaderText="Direccion" />
            <asp:BoundField DataField="telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="fecha_nacimiento" HeaderText="Nacimiento" DataFormatString="{0:d}" />
            <asp:BoundField DataField="tipo_de_sangre" HeaderText="tipo_de_sangre" />
        </Columns>
    </asp:GridView>
<script>
    function confirmDelete(event) {
        if (confirm("¿Seguro que quieres eliminar a este estudiante?")) {
            const row = event.target.closest(".data-row");
            const idEstudiante = row.dataset.row.id_estudiantes;

            fetch(`/eliminar/${idEstudiante}`, {
                method: "DELETE",
            })
                .then(response => {
                    if (response.ok) {
                        location.reload();
                    } else {
                        console.error("Error al eliminar estudiante");
                    }
                })
                .catch(error => {
                    console.error("Error al eliminar estudiante:", error);
                });
        }
    }
</script>  
</asp:Content>