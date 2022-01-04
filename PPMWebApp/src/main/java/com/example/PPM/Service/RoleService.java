package com.example.PPM.Service;

import java.util.List;

import com.example.PPM.Model.Role;

public interface RoleService 
{
	public List<Role> Get();
	
	public void Save(Role role);
	
	public Role GetById(int id);
	
	public void Delete(int id);
}
